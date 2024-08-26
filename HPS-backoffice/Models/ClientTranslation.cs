using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ClientTranslation
{
    public Guid Id { get; set; }

    public Guid? LanguageId { get; set; }

    public Guid? ClientId { get; set; }

    public string? Name { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Language? Language { get; set; }
}
