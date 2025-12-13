using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Post
{
    public int ID_Post { get; set; }

    public int ID_User { get; set; }

    public int? ID_Avaliacao { get; set; }

    public int ID_Local { get; set; }

    public byte[]? Url_Image { get; set; }

    public DateTime DataPostagem { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual Avaliacao? ID_AvaliacaoNavigation { get; set; }

    public virtual Locai ID_LocalNavigation { get; set; } = null!;

    public virtual Usuario ID_UserNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> ID_Users { get; set; } = new List<Usuario>();
}
