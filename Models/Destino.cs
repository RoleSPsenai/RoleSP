using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Destino
{
    public int ID_Destino { get; set; }

    public int ID_User { get; set; }

    public int ID_Post { get; set; }

    public virtual Post ID_PostNavigation { get; set; } = null!;

    public virtual Usuario ID_UserNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
