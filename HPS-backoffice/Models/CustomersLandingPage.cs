using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class CustomersLandingPage
{
    public Guid Id { get; set; }

    public Guid? HpsCustomerId { get; set; }

    public bool? IsPortal { get; set; }

    public string? FailureUrl { get; set; }

    public string? SuccessUrl { get; set; }

    public string? CancelUrl { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual HpsCustomer? HpsCustomer { get; set; }
}
