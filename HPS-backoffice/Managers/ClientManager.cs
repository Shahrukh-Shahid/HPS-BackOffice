using AutoMapper;
using HPS_backoffice.DTOs.Client;
using HPS_backoffice.DTOs.Common;
using HPS_backoffice.DTOs.Customer;
using HPS_backoffice.Interfaces;
using HPS_backoffice.Models;
using HPS_backoffice.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

namespace HPS_backoffice.Managers
{
    public class ClientManager : IClient
    {
        private readonly HPSContext _dbContext;
        private readonly IMapper _mapper;

        public ClientManager(IMapper mapper, HPSContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Response> CreateClient(ClientDto dto)
        {
            if (dto == null) { throw new ArgumentNullException(nameof(dto)); }

            Response returnVal = new Response(200, string.Empty, null);


            var cleint = _mapper.Map<Client>(dto);

            cleint.CreatedBy = null;
            cleint.CreatedOn = DateTime.Now;
            cleint.IsActive = true;
            cleint.IsDeleted = false;

            await _dbContext.Clients.AddAsync(cleint);
            await _dbContext.SaveChangesAsync();

            returnVal.StatusCode = 200;
            returnVal.Message = Constants.SuccessMessage;

            return returnVal;
        }

        public async Task<Response> UpdateClient(ClientDto dto)
        {
            if (!dto.Id.HasValue)
            {
                throw new Exception("Client id is required for update");
            }

            Client ct = await _dbContext.Clients
                        .FirstOrDefaultAsync(x => x.Id == dto.Id.Value && x.IsActive == true);

            Response returnVal = new Response(200, string.Empty, null);

            if (ct == null)
            {
                returnVal.StatusCode = 404;
                returnVal.Message = Constants.FailureMessage;
                return returnVal;
            }

            //checking for duplication

            var duplicateCheck = await _dbContext.Clients
                               .Where(x => x.Id != dto.Id &&
                               (x.Code == dto.Code || x.Name == dto.Name))
                               .FirstOrDefaultAsync();

            if (duplicateCheck != null)
            {
                returnVal.StatusCode = 409;
                returnVal.Message = Constants.DuplicationMessage;
                return returnVal;
            }

            ct.IsActive = dto.IsActive;
            ct.ModifiedBy = null;
            ct.ModifiedOn = DateTime.Now;
            ct.Name = dto.Name;
            ct.Code = dto.Code;

            await _dbContext.SaveChangesAsync();

            returnVal.StatusCode = 200;
            returnVal.Message = Constants.SuccessMessage;

            return returnVal;

        }

        public async Task<Response> ClientSubServiceMapping(ClientSubServiceDto dto)
        {
            if (!dto.ClientId.HasValue || !dto.SubServiceId.HasValue)
            {
                throw new Exception("ClientId and subServiceId is required");
            }

            Response returnVal = new Response(200, string.Empty, null);


            if (!dto.Id.HasValue)
            {
                var clientMapping = _mapper.Map<ClientSubService>(dto);

                clientMapping.CreatedBy = null;
                clientMapping.CreatedOn = DateTime.Now;
                clientMapping.IsActive = true;
                clientMapping.IsDeleted = false;

                await _dbContext.ClientSubServices.AddAsync(clientMapping);
                await _dbContext.SaveChangesAsync();

                returnVal.StatusCode = 200;
                returnVal.Message = Constants.SuccessMessage;

            }
            else
            {
                var existingMapping = await _dbContext.ClientSubServices
                                            .Where(x => x.Id == dto.Id)
                                            .FirstOrDefaultAsync();

                if (existingMapping == null)
                {
                    returnVal.StatusCode = 404;
                    returnVal.Message = Constants.FailureMessage;
                    return returnVal;
                }

                existingMapping.ModifiedBy = null;
                existingMapping.ModifiedOn = DateTime.Now;
                existingMapping.IsActive = dto.IsActive;
                existingMapping.SubServiceId = dto.SubServiceId;

                await _dbContext.SaveChangesAsync();

                returnVal.StatusCode = 200;
                returnVal.Message = Constants.UpdateMessage;
            }

            return returnVal;
        }

        public async Task<Response> GetClients(SearchFilters? filters)
        {
            Response returnVal = new Response(200, string.Empty, null);

            IQueryable<Client> query = _dbContext.Clients.AsQueryable();
            // Apply filters if provided
            if (filters != null)
                query = QueryHelper.ApplyFilters(query, filters);
            else
                query = query.Where(x => x.IsActive == true && x.IsDeleted == false);

            // Execute the query and select the required fields
            List<ClientDto> result = await query
                                           .Select(res => new ClientDto
                                           {
                                               Id = res.Id,
                                               Name = res.Name,
                                               Code = res.Code,
                                               CreatedOn = res.CreatedOn,
                                               CreatedBy=res.CreatedBy,
                                               ModifiedOn = res.ModifiedOn,
                                               ModifiedBy = res.ModifiedBy,
                                               IsActive = res.IsActive,
                                               Logo=res.Logo
                                           })
                                           .ToListAsync();

            returnVal.Data = result.Any() ? result : null;
            returnVal.StatusCode = 200;
            returnVal.Message = result.Any() ? Constants.SuccessMessage : Constants.RecordNotFound;

            return returnVal;
        }

        public async Task<Response> GetClientsSubService(SearchFilters? filters)
        {
            Response returnVal = new Response(200, string.Empty, null);

            IQueryable<ClientSubServiceMapDto> query = from c in _dbContext.ClientSubServices
                                                       select new ClientSubServiceMapDto
                                                       {
                                                           Id = c.Id,
                                                           Name = c.Name,
                                                           ClientTypeCode = c.ClientTypeCode,
                                                           Client = c.Client.Name,
                                                           SubService = c.SubService.Name,
                                                           Price = c.Price,
                                                           CreatedOn = c.CreatedOn,
                                                           CreatedBy = c.CreatedBy,
                                                           ModifiedOn = c.ModifiedOn,
                                                           ModifiedBy = c.ModifiedBy,
                                                           IsActive = c.IsActive
                                                       };

            // Apply filters if provided
            if (filters != null)
                query = QueryHelper.ApplyFilters(query, filters);
            else
                query = query.Where(x => x.IsActive == true && x.IsDeleted == false);

            // Execute the query and select the required fields
            var result = await query.ToListAsync();

            returnVal.Data = result.Any() ? result : null;
            returnVal.StatusCode = 200;
            returnVal.Message = result.Any() ? Constants.SuccessMessage : Constants.RecordNotFound;

            return returnVal;
        }
    }
}
