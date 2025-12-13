using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NomeCompleto { get; set; } = null!;

    public string? NomeUsuario { get; set; }

    public string Email { get; set; } = null!;

    public byte[] Senha { get; set; } = null!;

    public byte[]? Foto { get; set; }

    public DateTime CriadoEm { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Locai> ID_Locals { get; set; } = new List<Locai>();

    public virtual ICollection<Post> ID_Posts { get; set; } = new List<Post>();
}
