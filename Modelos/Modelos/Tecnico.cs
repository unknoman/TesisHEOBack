using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Tecnico
{
    public int Idtecnico { get; set; }

    public int Idestado { get; set; }

    public string Nombret { get; set; } = null!;

    public string Apellidot { get; set; } = null!;

    public int Casosnum { get; set; }

    public string Telefonot { get; set; } = null!;

    public virtual Estadot IdestadoNavigation { get; set; } = null!;

    public virtual ICollection<Serviciotecnico> Serviciotecnicos { get; set; } = new List<Serviciotecnico>();

    public bool activo { get; set; }
}
