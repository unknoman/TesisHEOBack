using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Route("obtenerDatos")]
        public Dictionary<string, int> getDatos()
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                var Stats = db.Servicios.Include(s => s.Clientes)
               .ToDictionary(s => s.Servicio1, s => s.Clientes.Count);
                return Stats;
            }
        }

    }
}
