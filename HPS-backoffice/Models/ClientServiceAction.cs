using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ClientServiceAction
{
    public Guid Id { get; set; }

    public string? ActionType { get; set; }

    public string? ActionCode { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<ClientSubServiceDetail> ClientSubServiceDetails { get; set; } = new List<ClientSubServiceDetail>();
}
