namespace HPS_backoffice.DTOs.Client
{
    public class ClientSubServiceDto
    {
        public Guid? Id { get; set; }

        public Guid? ClientId { get; set; }

        public Guid? SubServiceId { get; set; }

        public string? Name { get; set; }

        public string? ClientTypeCode { get; set; }

        public decimal? Price { get; set; }

        public bool? ExternalUse { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }

    public class ClientSubServiceMapDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }

        public string? ClientTypeCode { get; set; }
        public Guid? ClientId { get; set; }
        public string? Client { get; set; }
        public Guid? SubServiceId { get; set; }
        public string? SubService { get; set; }

        public decimal? Price { get; set; }

        public bool? ExternalUse { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }

}
