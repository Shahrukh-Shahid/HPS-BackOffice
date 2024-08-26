namespace HPS_backoffice.DTOs.Client
{
    public class ClientDto
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

        public string? Logo { get; set; }
    }
    public class ActiveClientDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = null!;
    }

    public class ActiveClientTypesDto
    {
        public Guid Id { get; set; }
        public string ClientType1 { get; set; } = null!;
    }


}
