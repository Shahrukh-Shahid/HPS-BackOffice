using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ClientSubServiceDetail
{
    public Guid Id { get; set; }

    public Guid? ClientSubServiceId { get; set; }

    public Guid? ClientServiceActionId { get; set; }

    public string? QuotationUrl { get; set; }

    public string? GeneratePolicyUrl { get; set; }

    public string? GetPolicyReportUrl { get; set; }

    public string? GetPolicyDetailUrl { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ClientServiceAction? ClientServiceAction { get; set; }

    public virtual ClientSubService? ClientSubService { get; set; }
}
