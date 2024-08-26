namespace HPS_backoffice.DTOs.Customer
{
    public class CustomerDto
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
    }
}
