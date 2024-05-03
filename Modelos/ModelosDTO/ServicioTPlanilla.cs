using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
    public class ServicioTPlanilla
    {
        public int idCaso { get; set; }

        public string descripcion { get; set; }
        public string nombreC { get; set; }

        public string apellidoC { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string tecnico { get; set; }


    }
}
