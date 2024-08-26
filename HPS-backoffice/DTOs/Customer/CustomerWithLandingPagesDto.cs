namespace HPS_backoffice.DTOs.Customer
{
    public class CustomerWithLandingPagesDto
    {
        public Guid? Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? Description { get; set; }
        public string SecretKey { get; set; } = null!;
        public string? IncomingRoute { get; set; }
        public string OutgoingRoute { get; set; } = null!;
        public DateTime? RegistrationDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        // Landing pages
        public LandingPageDto PortalLandingPage { get; set; } = null!;
        public LandingPageDto NonPortalLandingPage { get; set; } = null!;
    }

    public class LandingPageDto
    {
        public string? FailureUrl { get; set; }
        public string? SuccessUrl { get; set; }
        public string? CancelUrl { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class LandingPageUpdateDto
    {
        public Guid? Id { get; set; }
        public Guid? CustomerId { get; set; }
        public LandingPageDto PortalLandingPage { get; set; } = null!;
        public LandingPageDto NonPortalLandingPage { get; set; } = null!;
    }

}
