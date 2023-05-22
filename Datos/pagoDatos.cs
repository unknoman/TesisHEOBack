using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Datos
{
   public static class pagoDatos
    {


        public static List<pagoDTO> listarPagos(int id)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
               List<pagoDTO> pagosCliente = db.Pagos.Where(c => c.Idcliente == id).Select(c => new pagoDTO
                {
                    Idfactura = c.Idfactura,
                    Fecha = c.Fecha,
                    Fechavencimiento = c.Fechavencimiento,
                    Fechapagado = c.Fechapagado,
                    Preciototal = c.Preciototal,
                    servicio = c.IdservicioNavigation.Servicio1,
                    estado = c.IdestadopNavigation.Estadop1

                }).ToList() ;
                return pagosCliente;
            }
        }

    }

}

