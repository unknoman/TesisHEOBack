using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ServiciosDatos
{
   public class ExcepcionDatos : Exception
    {
        public ExcepcionDatos(string? message) : base(message)
        {
        }
        public ExcepcionDatos(string mensaje, Exception ex) : base(mensaje, ex)
        {
        }
    }
}
