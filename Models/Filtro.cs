using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoleSP.Models;

[Table("Filtro")]
public partial class Filtro
{
    [Key]
    public int IdFiltro { get; set; }

    [StringLength(120)]
    public string NomeFiltro { get; set; } = null!;

    [InverseProperty("IdFiltroNavigation")]
    public virtual ICollection<Locai> Locais { get; set; } = new List<Locai>();
}
