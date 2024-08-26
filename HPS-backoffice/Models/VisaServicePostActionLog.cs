using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class VisaServicePostActionLog
{
    public Guid Id { get; set; }

    public Guid? TransactionId { get; set; }

    public bool? PartiallyUpdateMannai { get; set; }

    public bool? PolicyGenerated { get; set; }

    public bool? PdfDownloaded { get; set; }

    public bool? UpdateMoi { get; set; }

    public bool? UpdateMannai { get; set; }

    public bool? IsLock { get; set; }

    public DateTime? RequestTime { get; set; }

    public DateTime? CompletionTime { get; set; }

    public bool? IsCompleted { get; set; }

    public virtual Transaction? Transaction { get; set; }
}
