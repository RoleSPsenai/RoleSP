using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Usuario
{
    public int ID_User { get; set; }

    public string Email { get; set; } = null!;

    public string? Nome { get; set; }

    public string? Apelido { get; set; }

    public byte[] SenhaHash { get; set; } = null!;

    public DateTime? DataCriacao { get; set; }

    public string? ImagemPerfil { get; set; }

    public int? ID_Destino { get; set; }

    public int? ID_Favorito { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Destino> Destinos { get; set; } = new List<Destino>();

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual Destino? ID_DestinoNavigation { get; set; }

    public virtual Favorito? ID_FavoritoNavigation { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
