using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class VisitDurationCode
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
