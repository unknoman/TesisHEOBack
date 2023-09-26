using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public int? Idservicio { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dnic { get; set; } = null!;

    public decimal Pagopendiente { get; set; }

    public int Idestadoc { get; set; }

    public string Direccionc { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int instalado { get; set; }
    public virtual Estadocliente IdestadocNavigation { get; set; } = null!;

    public virtual Servicio? IdservicioNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Serviciotecnico> Serviciotecnicos { get; set; } = new List<Serviciotecnico>();
}
