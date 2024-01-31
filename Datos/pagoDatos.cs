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
                List<pagoDTO> pagosCliente = db.Pagos.Where(c => c.Idcliente == id).OrderByDescending(c => c.Idfactura).Select(c => new pagoDTO
                {
                    Idfactura = c.Idfactura,
                    Fecha = c.Fecha,
                    Fechavencimiento = c.Fechavencimiento,
                    Fechapagado = c.Fechapagado,
                    Preciototal = c.Preciototal,
                    servicio = c.Serviciop,
                    idestadop = c.Idestadop,
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
        /* datos en la base de datos
         * estadocliente
     1 activo
     2 suspendido
     3 pendiente

     estadop
     1 pendiente
     2 pagado
     3 vencido
         * */ 
        public static dynamic cambiarEstadoP(pagoUpdateDTO pago)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                if (pago.Idfactura == 0 || pago.Idfactura == null)
                {
                    return false;
                }

                Pago pago1 = db.Pagos.FirstOrDefault(s => s.Idfactura == pago.Idfactura);

                if (pago1 == null)
                {
                    return false;
                }

                pago1.Idestadop = pago.Idestado;

                if (pago.Idestado != 2) // Estado diferente de "pagado"
                {
                    pago1.Fechapagado = null; // Establecer la fecha de pago como null
                }
                else // Estado "pagado"
                {
                    pago1.Fechapagado = DateTime.Now;
                }

                db.Update(pago1);
                int valor = db.SaveChanges();

                if (valor != 0)
                {
                    int idCliente = pago1.Idcliente;
                    bool clienteAlDia = !db.Pagos.Any(p => p.Idcliente == idCliente && p.Idestadop != 2);
                    bool clienteSuspendido = db.Pagos.Any(p => p.Idcliente == idCliente && p.Idestadop == 3);

                    Cliente? cliente = db.Clientes.FirstOrDefault(c => c.Idcliente == idCliente);

                    if (cliente != null)
                    {
                        if (clienteAlDia) // Todos los pagos están en estado "pagado"
                        {
                            cliente.Idestadoc = 1; // Cambiar el estado del cliente a "al día"
                        }
                        else if (clienteSuspendido) // Al menos un pago está en estado "vencido"
                        {
                            cliente.Idestadoc = 2; // Cambiar el estado del cliente a "suspendido"
                        }
                        else
                        {
                            cliente.Idestadoc = 3; // Cambiar el estado del cliente a "pendiente"
                        }

                        db.Update(cliente); // Actualizar la tabla Cliente
                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }




    }
}

