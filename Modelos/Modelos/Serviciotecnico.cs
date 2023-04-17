using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Serviciotecnico
{
    public int Idproblemat { get; set; }

    public int? Idtecnico { get; set; }

    public int Idcliente { get; set; }

    public int Idestadoservicio { get; set; }

    public int Idtiposerviciot { get; set; }

    public string? Descripcionserviciot { get; set; }

    public DateTime Fechainicio { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual Estadoservicio IdestadoservicioNavigation { get; set; } = null!;

    public virtual Tecnico? IdtecnicoNavigation { get; set; }

    public virtual Tiposervicio IdtiposerviciotNavigation { get; set; } = null!;
}
