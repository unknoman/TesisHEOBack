using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Estadocliente
{
    public int Idestadoc { get; set; }

    public string? Estadocliente1 { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
