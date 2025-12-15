using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Post
{
    public int IdPost { get; set; }

    public int IdUsuario { get; set; }

    public int IdAvalicao { get; set; }

    public int IdLocais { get; set; }

    public byte[] Imagem { get; set; } = null!;

    public DateTime CriadoEm { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual Avaliacao IdAvalicaoNavigation { get; set; } = null!;

    public virtual Locai IdLocaisNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> IdUsuariosNavigation { get; set; } = new List<Usuario>();
}
