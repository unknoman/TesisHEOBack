using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Modelos.ModelosDTO
{
    public class ServicioTDTO
    {

        public int Idproblemat { get; set; }

        public int idtecnico { get; set; }
        public int Idestadoservicio { get; set; }

        public int Idtiposerviciot { get; set; }

        public string Descripcionserviciot { get; set; }

        public DateTime Fechainicio { get; set; }

       public string direccion { get; set; }
        public string clienteN { get; set; }

        public string clienteA { get; set; }

        public string dnic { get; set; }

        public string? tecnico { get; set; } 


    }
}
