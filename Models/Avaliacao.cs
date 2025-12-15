using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Avaliacao
{
    public int IdAvaliacao { get; set; }

    public int IdUsuario { get; set; }

    public int? IdPost { get; set; }

    public string TextoAvaliacao { get; set; } = null!;

    public virtual Post IdPostNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
