using HPS_backoffice.DTOs.Client;
using HPS_backoffice.DTOs.Common;
using HPS_backoffice.DTOs.Customer;
using HPS_backoffice.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HPS_backoffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _service;
        public CustomerController(ICustomer service)
        {
            _service = service;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerDto dto)
        {
            var result = await _service.CreateCustomer(dto);
            return Ok(result);
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerDto dto)
        {
            var result = await _service.UpdateCustomer(dto);
            return Ok(result);
        }

        [HttpPost("AddCustomerLandingPage")]
        public async Task<IActionResult> AddCustomerLandingPage(CustomerLandingDto dto)
        {
            var result = await _service.AddCustomerLandingPage(dto);
            return Ok(result);
        }

        [HttpPost("CreateCustomerWithLandingPage")]
        public async Task<IActionResult> CreateCustomerWithLandingPage(CustomerWithLandingPagesDto dto)
        {
            var result = await _service.CreateCustomerWithLandingPage(dto);
            return Ok(result);
        }

        [HttpPost("UpdateLandingPage")]
        public async Task<IActionResult> UpdateLandingPage(LandingPageUpdateDto dto)
        {
            var result = await _service.UpdateLandingPage(dto);
            return Ok(result);
        }

        [HttpPost("GetCustomersListing")]
        public async Task<IActionResult> GetCustomers(SearchFilters? filters)
        {
            var result = await _service.GetCustomers(filters);
            return Ok(result);
        }

        [HttpPost("GetCustomersListingWithLandingPage")]
        public async Task<IActionResult> GetCustomersWithLandingPage(SearchFilters? filters)
        {
            var result = await _service.GetCustomersWithLandingPage(filters);
            return Ok(result);
        }
    }
}
