using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Estadop
{
    public int Idestadop { get; set; }

    public string Estadop1 { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
