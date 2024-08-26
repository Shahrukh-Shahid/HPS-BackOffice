namespace HPS_backoffice.DTOs.Service
{
    public class ServiceSubServiceDto
    {
        public Guid? Id { get; set; }

        public Guid? ServiceId { get; set; }

        public Guid? SubServiceId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }

    public class ServiceSubServiceMapDto
    {
        public Guid? Id { get; set; }

        public Guid? ServiceId { get; set; }
        public string? Service { get; set; }
        public string? ServiceCode { get; set; }
        public Guid? SubServiceId { get; set; }
        public string? SubService { get; set; }
        public string? SubServiceCode { get; set; }
        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
