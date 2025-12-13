using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Avaliacao
{
    public int ID_Avaliacao { get; set; }

    public decimal Nota { get; set; }

    public DateTime DataAvaliacao { get; set; }

    public int ID_Usuario { get; set; }

    public int? ID_Post { get; set; }

    public string? Comentario { get; set; }

    public virtual Post? ID_PostNavigation { get; set; }

    public virtual Usuario ID_UsuarioNavigation { get; set; } = null!;

    public virtual Post? Post { get; set; }
}
