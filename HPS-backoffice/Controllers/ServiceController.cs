using HPS_backoffice.DTOs.Common;
using HPS_backoffice.DTOs.Customer;
using HPS_backoffice.DTOs.Service;
using HPS_backoffice.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HPS_backoffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService _service;
        public ServiceController(IService service)
        {
            _service = service;
        }

        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(ServiceDto dto)
        {
            var result = await _service.CreateService(dto);
            return Ok(result);
        }

        [HttpPost("UpdateService")]
        public async Task<IActionResult> UpdateService(ServiceDto dto)
        {
            var result = await _service.UpdateService(dto);
            return Ok(result);
        }

        [HttpPost("CreateSubService")]
        public async Task<IActionResult> CreateSubService(SubServiceDto dto)
        {
            var result = await _service.CreateSubService(dto);
            return Ok(result);
        }

        [HttpPost("UpdateSubService")]
        public async Task<IActionResult> UpdateSubService(SubServiceDto dto)
        {
            var result = await _service.UpdateSubService(dto);
            return Ok(result);
        }

        [HttpPost("ServiceMapping")]
        public async Task<IActionResult> MappingService(ServiceSubServiceDto dto)
        {
            var result = await _service.MappingService(dto);
            return Ok(result);
        }

        [HttpPost("GetServiceListing")]
        public async Task<IActionResult> GetServices(SearchFilters? filters)
        {
            var result = await _service.GetServices(filters);
            return Ok(result);
        }

        [HttpPost("GetSubServicesListin")]
        public async Task<IActionResult> GetSubServices(SearchFilters? filters)
        {
            var result = await _service.GetSubServices(filters);
            return Ok(result);
        }

        [HttpPost("GetServicesSubServicesListing")]
        public async Task<IActionResult> GetServicesSubServices(SearchFilters? filters)
        {
            var result = await _service.GetServicesSubServices(filters);
            return Ok(result);
        }
    }
}
