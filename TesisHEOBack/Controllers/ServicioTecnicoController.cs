using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}
