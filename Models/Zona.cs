using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Zona
{
    public int ID_Zona { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Local> Locals { get; set; } = new List<Local>();
}
