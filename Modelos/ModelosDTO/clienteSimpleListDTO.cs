using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
    public class clienteSimpleListDTO
    {
        public int Idcliente { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Dnic { get; set; } = null!;

        public decimal Instalado { get; set; } 

        public decimal Pagopendiente { get; set; }

    }
}
