using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Estadoservicio
{
    public int Idestadoservicio { get; set; }

    public string Estadoservicio1 { get; set; } = null!;

    public virtual ICollection<Serviciotecnico> Serviciotecnicos { get; set; } = new List<Serviciotecnico>();
}
