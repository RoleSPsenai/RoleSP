using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Comentario
{
    public int ID_Comentario { get; set; }

    public DateOnly? DataComentario { get; set; }

    public string? Texto { get; set; }

    public int ID_Post { get; set; }

    public int ID_User { get; set; }

    public virtual Post ID_PostNavigation { get; set; } = null!;

    public virtual Usuario ID_UserNavigation { get; set; } = null!;
}
