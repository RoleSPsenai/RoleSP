using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoleSP.Models;

[Table("Post")]
public partial class Post
{
    [Key]
    public int IdPost { get; set; }

    public int IdUsuario { get; set; }

    public int IdLocais { get; set; }

    public byte[] Imagem { get; set; } = null!;

    [Precision(0)]
    public DateTime CriadoEm { get; set; }

    public int? IdAvalicao { get; set; }

    [StringLength(500)]
    public string? Avaliacao { get; set; }

    [ForeignKey("IdLocais")]
    [InverseProperty("Posts")]
    public virtual Locai IdLocaisNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Posts")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [ForeignKey("IdPost")]
    [InverseProperty("IdPosts")]
    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();

    [ForeignKey("IdPost")]
    [InverseProperty("IdPostsNavigation")]
    public virtual ICollection<Usuario> IdUsuariosNavigation { get; set; } = new List<Usuario>();
}
