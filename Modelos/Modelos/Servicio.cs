using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Servicio
{
    public int Idservicio { get; set; }

    public string Servicio1 { get; set; } = null!;

    public string Subida { get; set; } = null!;

    public decimal Precio { get; set; }

    public string Bajada { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public bool activo { get; set; }
}
