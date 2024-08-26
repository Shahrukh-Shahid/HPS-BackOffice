using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ClientType
{
    public Guid Id { get; set; }

    public string? ClientType1 { get; set; }

    public string? ClientTypeCode { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
