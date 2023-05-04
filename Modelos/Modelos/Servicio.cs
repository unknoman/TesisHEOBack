using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Servicio
{
    public int Idservicio { get; set; }

    public string Servicio1 { get; set; } = null!;

    public string? Bajada { get; set; }

    public string? Subida { get; set; }

    public decimal Precio { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
