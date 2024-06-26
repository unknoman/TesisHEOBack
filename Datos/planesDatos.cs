﻿using Microsoft.EntityFrameworkCore;
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
                List<servicioDTO> serviciosList = db.Servicios.Where(p => p.activo != false).Select(c => new servicioDTO
                {
                    Idservicio = c.Idservicio,
                    Servicio1 = c.Servicio1,
                    Subida = c.Subida,
                    Bajada = c.Bajada,
                    Precio = c.Precio

                }).OrderByDescending(c => c.Idservicio).ToList();
                return serviciosList;
            }
        }

        public static dynamic eliminarPlan(int id)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                Servicio servicio = db.Servicios.Include(s => s.Clientes).FirstOrDefault(s => s.Idservicio == id);
                
                if (servicio != null && servicio.Clientes.Count < 1)
                {

                        servicio.activo = false;
                        db.Update(servicio);
                        db.SaveChanges();
                        return true;
                }
                else
                {
                    return false;
                }

            }

        }


        public static dynamic actualizarPlan(servicioDTO plan)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                Servicio servicio = db.Servicios.FirstOrDefault(u => u.Idservicio == plan.Idservicio);
                if (!String.IsNullOrEmpty(plan.Servicio1) && plan.Idservicio != 0)
                {
                    servicio.Servicio1 = plan.Servicio1;
                    servicio.Precio = plan.Precio;
                    servicio.Bajada = plan.Bajada;
                    servicio.Subida = plan.Subida;
                    db.Update(servicio);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
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
