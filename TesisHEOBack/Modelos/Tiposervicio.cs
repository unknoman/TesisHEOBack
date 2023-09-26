using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Tiposervicio
{
    public int Idtiposerviciot { get; set; }

    public string Tiposervicio1 { get; set; } = null!;

    public virtual ICollection<Serviciotecnico> Serviciotecnicos { get; set; } = new List<Serviciotecnico>();
}
