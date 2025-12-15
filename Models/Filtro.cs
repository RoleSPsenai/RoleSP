using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Filtro
{
    public int IdFiltro { get; set; }

    public string NomeFiltro { get; set; } = null!;

    public virtual ICollection<Locai> Locais { get; set; } = new List<Locai>();
}
