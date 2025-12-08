using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Post
{
    public int ID_Post { get; set; }

    public int? Avaliacao { get; set; }

    public DateOnly? DataPost { get; set; }

    public string? Legenda { get; set; }

    public string? Imagem { get; set; }

    public int ID_User { get; set; }

    public int ID_Local { get; set; }

    public int? ID_Favorito { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Destino> Destinos { get; set; } = new List<Destino>();

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual Favorito? ID_FavoritoNavigation { get; set; }

    public virtual Local ID_LocalNavigation { get; set; } = null!;

    public virtual Usuario ID_UserNavigation { get; set; } = null!;
}
