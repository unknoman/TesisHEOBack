using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Options;
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
                    servicio = c.Serviciop,
                    estado = c.IdestadopNavigation.Estadop1

                }).ToList() ;
                return pagosCliente;
            }
        }



        public static List<estadopDTO> listarEstadoPagos()
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                List<estadopDTO> EstadosP = db.Estadops.Select(c => new estadopDTO
                {
                    Idestadop = c.Idestadop,
                    Estadop1 = c.Estadop1

                }).ToList();
                return EstadosP;
            }
        }
        public static dynamic cambiarEstadoP(pagoUpdateDTO pago)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                if (pago.Idfactura == 0 || pago.Idfactura == null)
                {
                    return false;
                }
                Pago pago1 = db.Pagos.FirstOrDefault(s => s.Idfactura == pago.Idfactura);

                pago1.Idestadop = pago.Idestado;

                if (pago.Idestado != 2) // Estado diferente de "pagado"
                {
                    pago1.Fechapagado = null; // Establecer la fecha de pago como null
                } else if (pago.Idestado == 2)
                {
                    pago1.Fechapagado = DateTime.Now;
                }

                db.Update(pago1);
                int valor = db.SaveChanges();
                if (valor != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



    }
}

