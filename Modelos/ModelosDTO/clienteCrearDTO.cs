using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
   public class clienteCrearDTO
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Dnic { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Direccionc { get; set; } = null!;

        public int idServicio { get; set; } = 0;

    }
}
