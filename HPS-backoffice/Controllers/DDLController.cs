using HPS_backoffice.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HPS_backoffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDLController : ControllerBase
    {
        private readonly IDDL _service;
        public DDLController(IDDL service)
        {
            _service = service;
        }

        #region Client
        [HttpGet("GetClientsForDDL")]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await _service.GetClients());
        }
        [HttpGet("GetClientsTypesForDDL")]
        public async Task<IActionResult> GetClientTypes()
        {
            return Ok(_service.GetClientTypes());
        }

        #endregion

        #region Services
        [HttpGet("GetServicesForDDL")]
        public async Task<IActionResult> GetServices()
        {
            return Ok(await _service.GetServices());
        }
        [HttpGet("GetSubServicesForDDL")]
        public async Task<IActionResult> GetSubServices()
        {
            return Ok(await _service.GetSubServices());
        }

        #endregion

        #region Vendors
        [HttpGet("GetVendorsForDDL")]
        public async Task<IActionResult> GetVendors()
        {
            return Ok(await _service.GetVendors());
        }

        #endregion
    }
}
