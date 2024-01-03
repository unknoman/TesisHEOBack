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
                fechaHasta = fechaHasta.Date.AddDays(1).AddTicks(-1); // Asegurar que incluya todo el último día

               
                /* var stats =  db.Pagos
                    .Where(p => p.Fechapagado >= fechaDesde && p.Fechapagado <= fechaHasta) // Filtrar por fechas
                    .GroupBy(p => p.Serviciop)
                    .Select(group => new EstadisticasDTO
                    {
                        name = group.Key, // Serviciop como name
                        value = group.Count() // Contar la cantidad de pagos para el servicio
                    })
                    .ToList();*/

                var stats = db.Servicios
            .Select(servicio => new EstadisticasDTO
            {
                name = servicio.Servicio1, // Nombre del servicio
                value = servicio.Clientes.Count(cliente => cliente.Idestadoc != 1001) // Cantidad de clientes para el servicio
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
                fechaHasta = fechaHasta.Date.AddDays(1); // Asegurar que incluya todo el último día

                var stats = db.Serviciotecnicos
                    .Where(p => p.Fechainicio >= fechaDesde && p.Fechainicio <= fechaHasta) // Filtrar por fechas
                    .GroupBy(p => new { p.Idtecnico, p.IdtecnicoNavigation.Nombret, p.IdtecnicoNavigation.Apellidot })
                    .Select(group => new EstadisticasDTO
                    {
                        name = group.Key.Nombret + " " + group.Key.Apellidot + " ID:" + group.Key.Idtecnico, 
                        value = group.Count() // Contar la cantidad de servicios técnicos para el técnico
                    })
                    .ToList();

                return stats;
            }
        }


    }
}
