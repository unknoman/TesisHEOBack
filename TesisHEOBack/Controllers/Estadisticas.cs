using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.ModelosDTO;
using TesisHEOBack.Modelos;

namespace TesisHEOBack.Controllers
{
    [ApiController]
    [Route("estadisticas")]
    public class Estadisticas : Controller
    {

        [HttpPost]
        [Route("tecnicoMasCasos")]
        public dynamic ObtenerTecnicosConMasServicios(System.DateTime fechaDesde, System.DateTime fechaHasta)
        {
            using (TesisHeoContext dbContext = new TesisHeoContext())
            {
                var tecnicosConMasServicios = dbContext.Serviciotecnicos
                    .Where(s => s.Fechainicio >= fechaDesde && s.Fechainicio <= fechaHasta && s.Idtecnico != 0)
                    .GroupBy(s => s.Idtecnico)
                    .Select(g => new
                    {
                        Idtecnico = g.Key.Value,
                        Nombret = g.First().IdtecnicoNavigation.Nombret,
                        Apellidot = g.First().IdtecnicoNavigation.Apellidot,
                        CantidadServicios = g.Count()
                    })
                    .OrderByDescending(x => x.CantidadServicios)
                    .ToList();

                // Obtener la cantidad total de servicios asignados durante las fechas especificadas
                int totalServicios = tecnicosConMasServicios.Sum(t => t.CantidadServicios);

                // Seleccionar los tres principales y agregar la entrada "Otros"
                var resultados = tecnicosConMasServicios.Take(3).ToList();
                resultados.Add(new
                {
                    Idtecnico = 0, // Puedes usar un valor especial para representar "Otros"
                    Nombret = "Otros",
                    Apellidot = "",
                    CantidadServicios = totalServicios - resultados.Sum(r => r.CantidadServicios)
                });

                return resultados;
            }
        }

       
              [HttpGet]
              [Route("obtenerDatosPlanes")]
        public List<EstadisticasDTO> GetDatosPlanes(DateTime fechaDesde, DateTime fechaHasta)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                fechaDesde = fechaDesde.Date;
                fechaHasta = fechaHasta.Date.AddDays(1).AddTicks(-1); 

               
                /* var stats =  db.Pagos
                    .Where(p => p.Fechapagado >= fechaDesde && p.Fechapagado <= fechaHasta) // Filtrar por fechas
                    .GroupBy(p => p.Serviciop)
                    .Select(group => new EstadisticasDTO
                    {
                        name = group.Key, // Serviciop como name
                        value = group.Count() // Contar la cantidad de pagos para el servicio
                    })
                    .ToList();*/

                var stats = db.Servicios.Where(servicio => servicio.Precio != 0)
            .Select(servicio => new EstadisticasDTO
            {
                name = servicio.Servicio1, 
                value = servicio.Clientes.Count(cliente => cliente.activo != false) 
            })
            .ToList();

                return stats;
            }
        }






        [HttpGet]
        [Route("obtenerdatosTecnicos")]
        public List<EstadisticasDTO> GetDatosTecnicos(DateTime fechaDesde, DateTime fechaHasta)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                fechaDesde = fechaDesde.Date;
                fechaHasta = fechaHasta.Date.AddDays(1); 

                var stats = db.Serviciotecnicos
                    .Where(p => p.Fechainicio >= fechaDesde && p.Fechainicio <= fechaHasta && p.Idtiposerviciot == 2)
                    .GroupBy(p => new { p.Idtecnico, p.IdtecnicoNavigation.Nombret, p.IdtecnicoNavigation.Apellidot })
                    .Select(group => new EstadisticasDTO
                    {
                        name = group.Key.Nombret + " " + group.Key.Apellidot + " ID:" + group.Key.Idtecnico, 
                        value = group.Count() 
                    })
                    .ToList();

                return stats;
            }
        }



        [HttpGet]
        [Route("obtenerdatosTecnicosR")]
        public List<EstadisticasDTO> GetDatosTecnicosR(DateTime fechaDesde, DateTime fechaHasta)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                fechaDesde = fechaDesde.Date;
                fechaHasta = fechaHasta.Date.AddDays(1); 

                var stats = db.Serviciotecnicos
                    .Where(p => p.Fechainicio >= fechaDesde && p.Fechainicio <= fechaHasta && p.Idtiposerviciot == 1)
                    .GroupBy(p => new { p.Idtecnico, p.IdtecnicoNavigation.Nombret, p.IdtecnicoNavigation.Apellidot })
                    .Select(group => new EstadisticasDTO
                    {
                        name = group.Key.Nombret + " " + group.Key.Apellidot + " ID:" + group.Key.Idtecnico,
                        value = group.Count() 
                    })
                    .ToList();

                return stats;
            }
        }


        [HttpGet]
        [Route("obtenerEstadisticaDatos")]
        public List<EstadisticasDTO> ObtenerEstadisticasPagos(DateTime fechaDesde, DateTime fechaHasta)
        {
            fechaDesde = fechaDesde.Date;
            fechaHasta = fechaHasta.Date.AddDays(1); 
            using (TesisHeoContext db = new TesisHeoContext())
            {
                var estadisticas = db.Pagos
                .Where(p => p.Fecha >= fechaDesde && p.Fecha <= fechaHasta)
                .GroupBy(p => p.IdestadopNavigation.Estadop1)
                .Select(group => new EstadisticasDTO
                {
                    name = group.Key,
                    value = group.Count()
                })
                .ToList();
                return estadisticas;
            }

        }
    }

}

