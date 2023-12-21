using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
    public class tecnicoModificarDTO
    {
        public int id { get; set; } = 0;
        public string Nombret { get; set; } = null!;

        public string Apellidot { get; set; } = null!;

        public string Telefonot { get; set;} = null!;
    }
}
