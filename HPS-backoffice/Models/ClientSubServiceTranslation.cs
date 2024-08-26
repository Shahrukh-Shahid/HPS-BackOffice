using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ClientSubServiceTranslation
{
    public Guid Id { get; set; }

    public Guid? ClientSubServiceId { get; set; }

    public Guid? LanguageId { get; set; }

    public string? Name { get; set; }

    public virtual ClientSubService? ClientSubService { get; set; }

    public virtual Language? Language { get; set; }
}
