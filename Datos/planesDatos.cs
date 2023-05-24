using Microsoft.EntityFrameworkCore;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Datos
{
   public static class planesDatos
    {
        public static List<servicioDTO> listarPlanes()
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                List<servicioDTO> serviciosList = db.Servicios.Select(c => new servicioDTO
                {
                    Idservicio = c.Idservicio,
                    Servicio1 = c.Servicio1,
                    Subida = c.Subida,
                    Bajada = c.Bajada,
                    Precio = c.Precio

                }).ToList();
                return serviciosList;
            }
        }

        public static dynamic eliminarPlan(int id)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                Servicio servicio = db.Servicios.Include(s => s.Clientes).FirstOrDefault(s => s.Idservicio == id);
                if (servicio != null )
                {
                    if(servicio.Clientes.Any())
                    {
                        return false;
                    } else
                    {
                        db.Servicios.Remove(servicio);
                        db.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return "El servicio no se encontró en la base de datos";
                }

            }

        }



        public static dynamic crearPlan(servicioDTO plan)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                Servicio servicio = new Servicio();

                servicio.Servicio1 = plan.Servicio1;
                servicio.Bajada = plan.Bajada;
                servicio.Subida = plan.Subida;
                servicio.Precio = plan.Precio;
                db.Servicios.Add(servicio);
               int registros = db.SaveChanges();
                if(registros > 0)
                {
                    return "El plan se registró correctamente";
                } else
                {
                    return "El plan no se pudo registrar";
                }
          } 
        }

    }
}
