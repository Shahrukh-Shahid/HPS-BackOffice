using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class VendorResponse
{
    public Guid Id { get; set; }

    public Guid? TransactionId { get; set; }

    public string? RequestBody { get; set; }

    public string? ResponseBody { get; set; }

    public DateTime? RequestOn { get; set; }

    public DateTime? ResponseTime { get; set; }

    public virtual Transaction? Transaction { get; set; }
}
