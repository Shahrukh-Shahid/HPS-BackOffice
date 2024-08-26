using AutoMapper;
using HPS_backoffice.DTOs.Client;
using HPS_backoffice.DTOs.Common;
using HPS_backoffice.DTOs.Service;
using HPS_backoffice.DTOs.Vendor;
using HPS_backoffice.Interfaces;
using HPS_backoffice.Models;
using HPS_backoffice.Utilities;
using Microsoft.EntityFrameworkCore;

namespace HPS_backoffice.Managers
{
    public class DDLManager : IDDL
    {
        private readonly HPSContext _dbContext;
        private readonly IMapper _mapper;

        public DDLManager(IMapper mapper, HPSContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        #region Clients
        public async Task<Response> GetClientTypes()
        {
            Response returnVal = new Response(200, string.Empty, null);

            List<ActiveClientTypesDto> ct = await _dbContext.ClientTypes
                                       .Where(x => x.IsActive == true && x.IsDeleted == false)
                                       .Select(x => new ActiveClientTypesDto { Id = x.Id, ClientType1 = x.ClientType1 })
                                       .ToListAsync();

            if (ct.Count == 0)
                returnVal.Message = Constants.RecordNotFound;
            else
            {
                returnVal.Message = Constants.RecordNotFound;
                returnVal.Data = ct;
            }
            returnVal.StatusCode = 200;

            return returnVal;
        }
        public async Task<Response> GetClients()
        {
            Response returnVal = new Response(200, string.Empty, null);

            List<ActiveClientDto> ct = await _dbContext.Clients
                                       .Where(x => x.IsActive == true && x.IsDeleted == false)
                                       .Select(x => new ActiveClientDto { Id = x.Id, Name = x.Name })
                                       .ToListAsync();

            if (ct.Count == 0)
                returnVal.Message = Constants.RecordNotFound;
            else
            {
                returnVal.Message = Constants.SuccessMessage;
                returnVal.Data = ct;
            }
            returnVal.StatusCode = 200;

            return returnVal;
        }

        #endregion

        #region Services

        public async Task<Response> GetServices()
        {
            Response returnVal = new Response(200, string.Empty, null);

            List<ActiveServiceDto> ct = await _dbContext.Services
                                       .Where(x => x.IsActive == true && x.IsDeleted == false)
                                       .Select(x => new ActiveServiceDto { Id = x.Id, Name = x.Name })
                                       .ToListAsync();

            if (ct.Count == 0)
                returnVal.Message = Constants.RecordNotFound;
            else
            {
                returnVal.Message = Constants.RecordNotFound;
                returnVal.Data = ct;
            }
            returnVal.StatusCode = 200;

            return returnVal;
        }
        public async Task<Response> GetSubServices()
        {
            Response returnVal = new Response(200, string.Empty, null);

            List<ActiveSubServiceDto> ct = await _dbContext.SubServices
                                       .Where(x => x.IsActive == true && x.IsDeleted == false)
                                       .Select(x => new ActiveSubServiceDto { Id = x.Id, Name = x.Name })
                                       .ToListAsync();

            if (ct.Count == 0)
                returnVal.Message = Constants.RecordNotFound;
            else
            {
                returnVal.Message = Constants.RecordNotFound;
                returnVal.Data = ct;
            }
            returnVal.StatusCode = 200;

            return returnVal;
        }

        #endregion

        #region Vendor
        public async Task<Response> GetVendors()
        {
            Response returnVal = new Response(200, string.Empty, null);

            List<ActiveVendorsDto> ct = await _dbContext.VendorDetails
                                       .Where(x => x.IsActive == true && x.IsDeleted == false)
                                       .Select(x => new ActiveVendorsDto { Id = x.Id, Name = x.Name })
                                       .ToListAsync();

            if (ct.Count == 0)
                returnVal.Message = Constants.RecordNotFound;
            else
            {
                returnVal.Message = Constants.RecordNotFound;
                returnVal.Data = ct;
            }
            returnVal.StatusCode = 200;

            return returnVal;
        }
        #endregion
    }
}
