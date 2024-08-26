using AutoMapper;
using HPS_backoffice.DTOs.Common;
using HPS_backoffice.DTOs.Service;
using HPS_backoffice.Interfaces;
using HPS_backoffice.Models;
using HPS_backoffice.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace HPS_backoffice.Managers
{
    public class ServiceManager : IService
    {
        private readonly HPSContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceManager(IMapper mapper, HPSContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Response> CreateService(ServiceDto dto)
        {
            Response returnVal = new Response(200, string.Empty, null);

            if (dto == null)
            {
                var serviceEntity = _mapper.Map<Service>(dto);

                serviceEntity.CreatedBy = null;
                serviceEntity.CreatedOn = DateTime.Now;
                serviceEntity.IsActive = true;
                serviceEntity.IsDeleted = false;

                await _dbContext.Services.AddAsync(serviceEntity);
                await _dbContext.SaveChangesAsync();

                returnVal.StatusCode = 200;
                returnVal.Message = Constants.SuccessMessage;
            }
            else
            {
                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
            }

            return returnVal;

        }

        public async Task<Response> UpdateService(ServiceDto dto)
        {
            Response returnVal = new Response(200, string.Empty, null);

            if (dto.Id.HasValue)
            {
                var serviceEntity = await _dbContext.Services
                                          .Where(x => x.Id == dto.Id.Value)
                                          .FirstOrDefaultAsync();
                if (serviceEntity == null)
                {
                    returnVal.StatusCode = 400;
                    returnVal.Message = Constants.FailureMessage;

                    return returnVal;
                }
                serviceEntity.ModifiedBy = null;
                serviceEntity.ModifiedOn = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                returnVal.StatusCode = 200;
                returnVal.Message = Constants.SuccessMessage;
            }
            else
            {
                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
            }

            return returnVal;
        }

        public async Task<Response> CreateSubService(SubServiceDto dto)
        {
            Response returnVal = new Response(200, string.Empty, null);

            if (dto == null)
            {
                var subServiceEntity = _mapper.Map<SubService>(dto);

                subServiceEntity.CreatedBy = null;
                subServiceEntity.CreatedOn = DateTime.Now;
                subServiceEntity.IsActive = true;
                subServiceEntity.IsDeleted = false;

                await _dbContext.SubServices.AddAsync(subServiceEntity);
                await _dbContext.SaveChangesAsync();

                returnVal.StatusCode = 200;
                returnVal.Message = Constants.SuccessMessage;
            }
            else
            {
                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
            }

            return returnVal;
        }

        public async Task<Response> UpdateSubService(SubServiceDto dto)
        {
            Response returnVal = new Response(200, string.Empty, null);

            if (dto.Id.HasValue)
            {
                var serviceEntity = await _dbContext.SubServices
                                          .Where(x => x.Id == dto.Id.Value)
                                          .FirstOrDefaultAsync();

                if (serviceEntity == null)
                {
                    returnVal.StatusCode = 400;
                    returnVal.Message = Constants.FailureMessage;

                    return returnVal;
                }

                var codeCheck = await _dbContext.SubServices
                                      .Where(x => x.Code == dto.Code)
                                      .FirstOrDefaultAsync();

                if (codeCheck != null)
                {
                    if (codeCheck.Id != serviceEntity.Id)
                    {
                        returnVal.StatusCode = 400;
                        returnVal.Message = Constants.DuplicationMessage;

                        return returnVal;
                    }
                    else
                        serviceEntity.Code = dto.Code;

                }
                serviceEntity.Name = dto.Name;
                serviceEntity.ModifiedBy = null;
                serviceEntity.ModifiedOn = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                returnVal.StatusCode = 200;
                returnVal.Message = Constants.SuccessMessage;
            }
            else
            {
                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
            }

            return returnVal;
        }

        public async Task<Response> MappingService(ServiceSubServiceDto dto)
        {
            Response returnVal = new Response(200, string.Empty, null);

            if (dto.Id.HasValue)
            {
                var existingServiceSubService = await _dbContext.ServiceSubServices
                                                .FirstOrDefaultAsync(sss => sss.Id == dto.Id);

                if (existingServiceSubService == null)
                {
                    throw new Exception("ServiceSubService not found");
                }

                existingServiceSubService.ModifiedBy = null;
                existingServiceSubService.ModifiedOn = DateTime.Now;
                existingServiceSubService.IsActive = true;
                existingServiceSubService.IsDeleted = false;

                _mapper.Map(dto, existingServiceSubService);

                await _dbContext.SaveChangesAsync();

                returnVal.StatusCode = 200;
                returnVal.Message = Constants.UpdateMessage;
            }
            else
            {
                var mapping = _mapper.Map<ServiceSubService>(dto);

                mapping.IsActive = true;
                mapping.IsDeleted = false;
                mapping.CreatedBy = null;
                mapping.CreatedOn = DateTime.Now;

                await _dbContext.ServiceSubServices.AddAsync(mapping);
                await _dbContext.SaveChangesAsync();
            }

            return returnVal;
        }

        public async Task<Response> GetServices(SearchFilters? filters)
        {
            Response returnVal = new Response(200, string.Empty, null);

            // Start with a base query
            IQueryable<Service> query = _dbContext.Services.AsQueryable();

            // Apply filtering logic if filters are provided
            if (filters != null)
                query = QueryHelper.ApplyFilters(query, filters);
            else
                query = query.Where(x => x.IsActive == true && x.IsDeleted == false);

            // Execute the query and select the required fields
            List<ServiceDto> serviceList = await query
                .Select(service => new ServiceDto
                {
                    Id = service.Id,
                    Name = service.Name,
                    Code = service.Code,
                    CreatedOn = service.CreatedOn,
                    CreatedBy = service.CreatedBy,
                    ModifiedOn = service.ModifiedOn,
                    ModifiedBy = service.ModifiedBy,
                    IsActive = service.IsActive,
                    IsDeleted = service.IsDeleted
                })
                .ToListAsync();

            // Handle the case where no records are found
            if (serviceList.Count == 0)
            {
                returnVal.Message = Constants.RecordNotFound;
            }
            else
            {
                returnVal.Message = Constants.SuccessMessage;
                returnVal.Data = serviceList;
            }

            returnVal.StatusCode = 200;
            return returnVal;
        }

        public async Task<Response> GetSubServices(SearchFilters? filters)
        {
            Response returnVal = new Response(200, string.Empty, null);

            IQueryable<SubService> query = _dbContext.SubServices.AsQueryable();

            // Apply filtering logic if filters are provided
            if (filters != null)
                query = QueryHelper.ApplyFilters(query, filters);
            else
                query = query.Where(x => x.IsActive == true && x.IsDeleted == false);

            // Execute the query and select the required fields
            List<SubServiceDto> subServiceList = await query
                .Select(service => new SubServiceDto
                {
                    Id = service.Id,
                    Name = service.Name,
                    Code = service.Code,
                    CreatedOn = service.CreatedOn,
                    CreatedBy = service.CreatedBy,
                    ModifiedOn = service.ModifiedOn,
                    ModifiedBy = service.ModifiedBy,
                    IsActive = service.IsActive,
                    IsDeleted = service.IsDeleted
                })
                .ToListAsync();

            if (subServiceList.Count == 0)
            {
                returnVal.Message = Constants.RecordNotFound;
            }
            else
            {
                returnVal.Message = Constants.SuccessMessage;
                returnVal.Data = subServiceList;
            }

            returnVal.StatusCode = 200;
            return returnVal;
        }

        public async Task<Response> GetServicesSubServices(SearchFilters? filters)
        {
            Response returnVal = new Response(200, string.Empty, null);

            IQueryable<ServiceSubServiceMapDto> query = from s in _dbContext.ServiceSubServices
                                                        join serv in _dbContext.Services on s.ServiceId equals serv.Id
                                                        join subserv in _dbContext.SubServices on s.SubServiceId equals subserv.Id
                                                        //where (filters == null || filters.IsActive == null || s.IsActive == filters.IsActive)
                                                        select new ServiceSubServiceMapDto
                                                        {
                                                            Id = s.Id,
                                                            ServiceId = s.ServiceId,
                                                            Service = serv.Name,
                                                            ServiceCode = serv.Code,
                                                            SubServiceId = s.SubServiceId,
                                                            SubService = subserv.Name,
                                                            SubServiceCode = subserv.Code,
                                                            CreatedOn = s.CreatedOn,
                                                            CreatedBy = s.CreatedBy,
                                                            ModifiedOn = s.ModifiedOn,
                                                            ModifiedBy = s.ModifiedBy,
                                                            IsActive = s.IsActive,
                                                            IsDeleted = s.IsDeleted
                                                        };

            // Apply filters if provided
            if (filters != null)
                query = QueryHelper.ApplyFilters(query, filters);
            else
                query = query.Where(x => x.IsActive == true && x.IsDeleted == false);

            var result = await query.ToListAsync();

            returnVal.Data = result.Any() ? result : null;
            returnVal.StatusCode = 200;
            returnVal.Message = result.Any() ? Constants.SuccessMessage : Constants.RecordNotFound;

            return returnVal;
        }

    }
}