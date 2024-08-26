using HPS_backoffice.DTOs.Common;
using HPS_backoffice.DTOs.Service;

namespace HPS_backoffice.Interfaces
{
    public interface IService
    {
        Task<Response> CreateService(ServiceDto dto);
        Task<Response> UpdateService(ServiceDto dto);
        Task<Response> CreateSubService(SubServiceDto dto);
        Task<Response> UpdateSubService(SubServiceDto dto);
        Task<Response> MappingService(ServiceSubServiceDto dto);

        Task<Response> GetServices(SearchFilters? filters);
        Task<Response> GetSubServices(SearchFilters? filters);
        Task<Response> GetServicesSubServices(SearchFilters? filters);

    }
}
