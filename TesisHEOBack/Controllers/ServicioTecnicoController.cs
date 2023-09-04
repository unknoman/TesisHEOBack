using Datos.ServiciosDatos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Modelos.ModelosDTO;
using Negocio;

namespace TesisHEOBack.Controllers
{
    [Route("api/ServicioT")]
    [ApiController]
    public class ServicioTecnicoController : Controller
    {
        private readonly ServicioTNegocio _ServicioTNegocio;

        public ServicioTecnicoController(ServicioTNegocio servicioTNegocio) {
        _ServicioTNegocio = servicioTNegocio;
        }

        [HttpGet]
        [Route("listarServicioT")]
        public dynamic listarServicioT()
        {
            return _ServicioTNegocio.obtenerLista();
        }

        [HttpPut]
        [Route("registrarCaso")]
        public async Task<IActionResult> registrarCaso(ServicioTCrearDTO servicio)
        {
            try
            {
                await Task.Run(() => _ServicioTNegocio.crearServicioT(servicio));
                return Ok("Se registró correctamente");
            } catch (ExcepcionDatos ex)
            {
                return BadRequest(ex.Message);
            }
         
        }

    }
}
