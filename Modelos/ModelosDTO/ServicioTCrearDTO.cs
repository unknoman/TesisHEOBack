using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Modelos.ModelosDTO
{
    public class ServicioTCrearDTO
    {
            public int? idcaso { get; set; }
            public int Idtecnico { get; set; }

            public int Idcliente { get; set; }

            public int Idestadoservicio { get; set; }

            public int Idtiposerviciot { get; set; }

            public string? Descripcionserviciot { get; set; }

            public DateTime Fechainicio { get; set; }

    }
}
