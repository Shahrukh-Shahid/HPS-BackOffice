using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ClientServiceLog
{
    public Guid Id { get; set; }

    public Guid? ClientServiceId { get; set; }

    public Guid? ClientServiceOptId { get; set; }

    public string? RequestBody { get; set; }

    public DateTime? RequestTime { get; set; }

    public string? ResponseBody { get; set; }

    public DateTime? RequestCompleted { get; set; }

    public virtual ClientSubService? ClientService { get; set; }

    public virtual ClientServiceOperation? ClientServiceOpt { get; set; }
}
