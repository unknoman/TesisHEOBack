using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Pago
{
    public int Idfactura { get; set; }

    public int Idcliente { get; set; }

    public int Idestadop { get; set; }

    public DateTime Fecha { get; set; }

    public DateTime Fechavencimiento { get; set; }

    public DateTime? Fechapagado { get; set; }

    public int Idservicio { get; set; }

    public decimal Preciototal { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual Estadop IdestadopNavigation { get; set; } = null!;

    public virtual Servicio IdservicioNavigation { get; set; } = null!;
}
