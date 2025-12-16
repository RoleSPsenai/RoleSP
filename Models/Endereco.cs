using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoleSP.Models;

[Table("Endereco")]
public partial class Endereco
{
    [Key]
    public int IdEndereco { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Rua { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Bairro { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Cidade { get; set; } = null!;

    public int Cep { get; set; }

    [InverseProperty("IdEnderecoNavigation")]
    public virtual ICollection<Locai> Locais { get; set; } = new List<Locai>();
}
