using Datos;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public static class pagoNegocio
    {

        public static List<pagoDTO> listarPagos(int id)
        {
         return pagoDatos.listarPagos(id);
        }

        public static dynamic listarEstadoPagos()
        {
            return pagoDatos.listarEstadoPagos();
        }

        public static dynamic cambiarEstadoP(pagoUpdateDTO pago)
        {
            return pagoDatos.cambiarEstadoP(pago);
        }

        }
}
