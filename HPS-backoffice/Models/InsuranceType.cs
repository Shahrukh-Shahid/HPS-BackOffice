using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class InsuranceType
{
    public Guid Id { get; set; }

    public string? Value { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
