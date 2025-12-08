using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Filtro
{
    public int ID_Filtro { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Local> ID_Locals { get; set; } = new List<Local>();
}
