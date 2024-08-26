using HPS_backoffice.DTOs.Common;
using HPS_backoffice.DTOs.Customer;

namespace HPS_backoffice.Interfaces
{
    public interface ICustomer
    {
        Task<Response> CreateCustomer(CustomerDto dto);
        Task<Response> UpdateCustomer(CustomerDto dto);

        Task<Response> AddCustomerLandingPage(CustomerLandingDto dto);


        Task<Response> CreateCustomerWithLandingPage(CustomerWithLandingPagesDto dto);
        Task<Response> UpdateLandingPage(LandingPageUpdateDto dto);

        Task<Response> GetCustomers(SearchFilters? filters);
        Task<Response> GetCustomersWithLandingPage(SearchFilters? filters);

    }
}
