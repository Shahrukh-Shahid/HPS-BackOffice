using HPS_backoffice.DTOs.Common;

namespace HPS_backoffice.Interfaces
{
    public interface IDDL
    {
        #region Clients DDL
        Task<Response> GetClients();
        Task<Response> GetClientTypes();
        #endregion

        #region Services DDL
        Task<Response> GetServices();
        Task<Response> GetSubServices();

        #endregion

        #region Vendor
        Task<Response> GetVendors();
        #endregion
    }
}
