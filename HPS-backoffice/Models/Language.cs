using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class Language
{
    public Guid Id { get; set; }

    public string? Language1 { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<ClientSubServiceTranslation> ClientSubServiceTranslations { get; set; } = new List<ClientSubServiceTranslation>();

    public virtual ICollection<ClientTranslation> ClientTranslations { get; set; } = new List<ClientTranslation>();
}
