using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class Client
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Logo { get; set; }

    public virtual ICollection<ClientSubService> ClientSubServices { get; set; } = new List<ClientSubService>();

    public virtual ICollection<ClientTranslation> ClientTranslations { get; set; } = new List<ClientTranslation>();
}
