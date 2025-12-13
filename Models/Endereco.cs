using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Endereco
{
    public int ID_Endereco { get; set; }

    public string Rua { get; set; } = null!;

    public string? Bairro { get; set; }

    public string Cidade { get; set; } = null!;

    public string CEP { get; set; } = null!;

    public virtual ICollection<Locai> Locais { get; set; } = new List<Locai>();
}
