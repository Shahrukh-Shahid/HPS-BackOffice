using HPS_backoffice.DTOs.Client;
using HPS_backoffice.DTOs.Common;
using HPS_backoffice.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HPS_backoffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _service;
        public ClientController(IClient service)
        {
            _service = service;
        }

        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient(ClientDto dto)
        {
            var result = await _service.CreateClient(dto);
            return Ok(result);
        }

        [HttpPost("UpdateClient")]
        public async Task<IActionResult> GetClientTypes(ClientDto dto)
        {
            var result = await _service.UpdateClient(dto);
            return Ok(result);
        }

        [HttpPost("MappedClientSubService")]
        public async Task<IActionResult> ClientSubServiceMapping(ClientSubServiceDto dto)
        {
            var result = await _service.ClientSubServiceMapping(dto);
            return Ok(result);
        }

        [HttpPost("GetClientListing")]
        public async Task<IActionResult> GetClients(SearchFilters? filters)
        {
            var result = await _service.GetClients(filters);
            return Ok(result);
        }

        [HttpPost("GetClientsSubServiceListing")]
        public async Task<IActionResult> GetClientsSubService(SearchFilters? filters)
        {
            var result = await _service.GetClientsSubService(filters);
            return Ok(result);
        }
    }
}
