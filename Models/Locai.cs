using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Locai
{
    public int IdLocais { get; set; }

    public int IdFiltro { get; set; }

    public int IdEndereco { get; set; }

    public string NomeLocal { get; set; } = null!;

    public virtual Endereco IdEnderecoNavigation { get; set; } = null!;

    public virtual Filtro IdFiltroNavigation { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
