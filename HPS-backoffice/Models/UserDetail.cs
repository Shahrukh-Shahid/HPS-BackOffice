using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class UserDetail
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsViewer { get; set; }
}
