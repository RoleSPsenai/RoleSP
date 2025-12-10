using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Favorito
{
    public int ID_Favorito { get; set; }

    public int ID_User { get; set; }

    public int ID_Post { get; set; }

    public virtual Post ID_PostNavigation { get; set; } = null!;

    public virtual Usuario ID_UserNavigation { get; set; } = null!;
}
