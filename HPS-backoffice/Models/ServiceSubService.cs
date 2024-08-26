using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ServiceSubService
{
    public Guid Id { get; set; }

    public Guid? ServiceId { get; set; }

    public Guid? SubServiceId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? VendorId { get; set; }

    public virtual Service? Service { get; set; }

    public virtual SubService? SubService { get; set; }
}
