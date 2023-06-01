using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Text.Json.Serialization;
using System.Text.Json;
using TesisHEOBack.Modelos;
using Modelos.ModelosDTO;
using Google.Type;
using Datos;

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


    }
}







