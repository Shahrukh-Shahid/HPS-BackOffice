using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ClientServiceOperation
{
    public Guid Id { get; set; }

    public string? ServiceOperation { get; set; }

    public string? ServiceOperationCode { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<ClientServiceLog> ClientServiceLogs { get; set; } = new List<ClientServiceLog>();
}
