using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NomeUsuario { get; set; } = null!;

    public string Apelido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Senha { get; set; } = null!;

    public byte[]? Foto { get; set; }

    public DateTime CriadoEm { get; set; }

    public int Destino { get; set; }

    public int Favorito { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Post> IdPosts { get; set; } = new List<Post>();

    public virtual ICollection<Post> IdPostsNavigation { get; set; } = new List<Post>();
}
