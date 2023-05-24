using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Text.Json.Serialization;
using System.Text.Json;
using TesisHEOBack.Modelos;
using Modelos.ModelosDTO;
using Google.Type;

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



    }
}







