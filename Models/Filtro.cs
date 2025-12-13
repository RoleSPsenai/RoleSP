using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Filtro
{
    public int ID_Filtro { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Locai> Locais { get; set; } = new List<Locai>();
}
