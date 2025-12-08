using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Local
{
    public int ID_Local { get; set; }

    public string? Endereco { get; set; }

    public int ID_Zona { get; set; }

    public string? ID_NomeLocal { get; set; }

    public int? ID_Avaliacao { get; set; }

    public virtual Zona ID_ZonaNavigation { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Filtro> ID_Filtros { get; set; } = new List<Filtro>();
}
