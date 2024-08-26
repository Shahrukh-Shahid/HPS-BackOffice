using HPS_backoffice.DTOs.Client;
using HPS_backoffice.DTOs.Common;

namespace HPS_backoffice.Interfaces
{
    public interface IClient
    {
        Task<Response> CreateClient(ClientDto dto);
        Task<Response> UpdateClient(ClientDto dto);
        Task<Response> ClientSubServiceMapping(ClientSubServiceDto dto);

        Task<Response> GetClients(SearchFilters? filters);
        Task<Response> GetClientsSubService(SearchFilters? filters);
    }
}
