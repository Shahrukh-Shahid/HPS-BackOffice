namespace HPS_backoffice.DTOs.Customer
{
    public class CustomerLandingDto
    {
        public Guid? Id { get; set; }

        public Guid? HpsCustomerId { get; set; }

        public bool? IsPortal { get; set; }

        public string? FailureUrl { get; set; }

        public string? SuccessUrl { get; set; }

        public string? CancelUrl { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
