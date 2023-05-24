using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
    public class servicioDTO
    {

        public int Idservicio { get; set; }

        public string Servicio1 { get; set; } = null!;

        public string Subida { get; set; } = null!;

        public decimal Precio { get; set; }

        public string Bajada { get; set; } = null!;

    }
}
