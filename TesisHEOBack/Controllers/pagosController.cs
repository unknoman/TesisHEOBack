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
    [Route("pagos")]
    public class pagosController : Controller
    {
        [HttpGet]
        [Route("pagosList")]
        public dynamic listarCliente(int id)
        {
            return pagoNegocio.listarPagos(id);

        }
        [HttpGet]
        [Route("listarEstadoPagos")]
        public dynamic listarEstadoPagos()
        {
            return pagoNegocio.listarEstadoPagos();
        }

        [HttpPatch]
        [Route("cambiarEstadoPago")]
        public dynamic cambiarEstadoP(pagoUpdateDTO pago)
        {
            return pagoNegocio.cambiarEstadoP(pago);
        }

    }
}







