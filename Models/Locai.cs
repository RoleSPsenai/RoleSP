using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoleSP.Models;

public partial class Locai
{
    [Key]
    public int IdLocais { get; set; }

    public int IdFiltro { get; set; }

    public int IdEndereco { get; set; }

    [StringLength(120)]
    public string NomeLocal { get; set; } = null!;

    [ForeignKey("IdEndereco")]
    [InverseProperty("Locais")]
    public virtual Endereco IdEnderecoNavigation { get; set; } = null!;

    [ForeignKey("IdFiltro")]
    [InverseProperty("Locais")]
    public virtual Filtro IdFiltroNavigation { get; set; } = null!;

    [InverseProperty("IdLocaisNavigation")]
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
