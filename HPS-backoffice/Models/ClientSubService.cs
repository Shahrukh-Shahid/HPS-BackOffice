using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ClientSubService
{
    public Guid Id { get; set; }

    public Guid? ClientId { get; set; }

    public Guid? SubServiceId { get; set; }

    public string? Name { get; set; }

    public string? ClientTypeCode { get; set; }

    public decimal? Price { get; set; }

    public bool? ExternalUse { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<ClientServiceLog> ClientServiceLogs { get; set; } = new List<ClientServiceLog>();

    public virtual ICollection<ClientSubServiceDetail> ClientSubServiceDetails { get; set; } = new List<ClientSubServiceDetail>();

    public virtual ICollection<ClientSubServiceTranslation> ClientSubServiceTranslations { get; set; } = new List<ClientSubServiceTranslation>();

    public virtual SubService? SubService { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
}
