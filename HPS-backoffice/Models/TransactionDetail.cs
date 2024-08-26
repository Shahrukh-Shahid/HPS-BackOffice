using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class TransactionDetail
{
    public Guid Id { get; set; }

    public Guid? TransactionId { get; set; }

    public Guid? ClientSubServiceId { get; set; }

    public string? OrderNo { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? CompletionTime { get; set; }

    public virtual ClientSubService? ClientSubService { get; set; }

    public virtual Transaction? Transaction { get; set; }
}
