using System;
using System.Collections.Generic;

namespace RoleSP.Models;

public partial class Endereco
{
    public int IdEndereco { get; set; }

    public string Rua { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public int Cep { get; set; }

    public virtual ICollection<Locai> Locais { get; set; } = new List<Locai>();
}
