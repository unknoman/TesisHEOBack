using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Estadot
{
    public int Idestado { get; set; }

    public string Estadot1 { get; set; } = null!;

    public virtual ICollection<Tecnico> Tecnicos { get; set; } = new List<Tecnico>();
}
