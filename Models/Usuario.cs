using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoleSP.Models;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [StringLength(120)]
    public string NomeUsuario { get; set; } = null!;

    [StringLength(120)]
    public string Apelido { get; set; } = null!;

    [StringLength(150)]
    public string Email { get; set; } = null!;

    [MaxLength(32)]
    public byte[] Senha { get; set; } = null!;

    public byte[]? Foto { get; set; }

    [Precision(0)]
    public DateTime CriadoEm { get; set; }

    public int Destino { get; set; }

    public int Favorito { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("IdUsuarios")]
    public virtual ICollection<Post> IdPosts { get; set; } = new List<Post>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("IdUsuariosNavigation")]
    public virtual ICollection<Post> IdPostsNavigation { get; set; } = new List<Post>();
}
