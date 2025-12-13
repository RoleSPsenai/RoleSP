using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Locai
{
    public int ID_Locais { get; set; }

    public int ID_Filtro { get; set; }

    public int ID_Endereco { get; set; }

    public virtual Endereco ID_EnderecoNavigation { get; set; } = null!;

    public virtual Filtro ID_FiltroNavigation { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Usuario> ID_Users { get; set; } = new List<Usuario>();
}
