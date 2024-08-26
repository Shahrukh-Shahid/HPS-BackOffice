namespace HPS_backoffice.DTOs.Common
{
    public class SearchFilters
    {
        public Guid? Id { get; set; } //Filtering by id
        public Guid? ServiceId { get; set; } //Filtering by Serviceid
        public Guid? SubServiceId { get; set; } //Filtering by SubServiceid
        public Guid? ClientId { get; set; } //Filtering by clientId
        public string? SearchTerm { get; set; } // For keyword or text-based search
        public string? SortBy { get; set; } // Property name to sort by
        public bool SortDescending { get; set; } = false; // Sorting order
        public int PageNumber { get; set; } = 1; // Pagination: default to first page
        public int PageSize { get; set; } = 10; // Pagination: default to 10 records per page
        public DateTime? CreatedDate { get; set; } // For date range filtering
        public DateTime? ModifiedDate { get; set; } // For date range filtering
        public Guid? CreatedBy { get; set; } // Filtering by created by
        public Guid? ModifiedBy { get; set; } // Filtering by modified by
        public bool? IsActive { get; set; } // Filtering by status
    }
}
