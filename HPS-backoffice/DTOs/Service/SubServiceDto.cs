namespace HPS_backoffice.DTOs.Service
{
    public class SubServiceDto
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
