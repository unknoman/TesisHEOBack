using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Text.Json.Serialization;
using System.Text.Json;
using TesisHEOBack.Modelos;
using Modelos.ModelosDTO;
using Google.Type;
using Datos;

/* Aprendiendo patrones de diseño me di cuenta que podia simplificar bastante el codigo con la inyeccion de dependencias.
Voy a continuar el codigo de esta manera ya que esta empezado, pero entendí que la inyeccion de dependencia me podria haber simplificado mucho el codigo

*/

namespace TesisHEOBack.Controllers
{

    [ApiController]
    [Route("tecnico")]
    public class tecnicoController : Controller
    {

        [HttpGet]
        [Route("listarTecnico")]
        public dynamic listarTecnico(int numero = 0, string? nombre = "")
        {
            return tecnicoNegocio.listarTecnico(numero, nombre);
        }


      /*  [HttpPatch]
        [Route("modificarTecnico")]
        public dynamic modificarTecnico(Tecnico dto)
        {
            
        }
       */



        [HttpPut]
        [Route("crearTecnico")]
        public dynamic crearTecnico(tecnicoDTO tecnico)
        {
            return tecnicoNegocio.crearTecnico(tecnico);
        }

        [HttpDelete]
        [Route("eliminarTecnico")]
        public dynamic eliminarTecnico(int id)
        {
            return tecnicoNegocio.eliminarTecnico(id);
        }
        [HttpGet]
        [Route("listarTecnicoDisponible")]
        public dynamic listarTecnicosDisponibles()
        {
            return tecnicoNegocio.listarTecnicosDisponibles();
        }
    }
}







