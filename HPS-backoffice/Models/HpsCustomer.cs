using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class HpsCustomer
{
    public Guid Id { get; set; }

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

    public virtual ICollection<CustomersLandingPage> CustomersLandingPages { get; set; } = new List<CustomersLandingPage>();

    public virtual ICollection<ExternalUser> ExternalUsers { get; set; } = new List<ExternalUser>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
