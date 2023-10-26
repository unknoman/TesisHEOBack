using Datos.ServiciosDatos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Modelos.Modelos;
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
        public dynamic listarServicioT(int estado)
        {
            return _ServicioTNegocio.obtenerLista(estado);
        }

        [HttpPatch]
        [Route("actualizarCaso")]
        public dynamic actualizarCaso(ServicioTCrearDTO servicio)
        {
            respuesta respuesta1 = new respuesta();
            try
            {
                 _ServicioTNegocio.actualizarServicioT(servicio);
                respuesta1.estadoRespuesta = true;
                respuesta1.mensajeRespuesta = "El caso fue actualizado correctamente";
                return respuesta1;
            }
            catch (ExcepcionDatos ex)
            {
                respuesta1.estadoRespuesta = false;
                respuesta1.mensajeRespuesta = ex.Message;
                return respuesta1;
            }
        }


        [HttpPut]
        [Route("registrarCaso")]
        public async Task<dynamic> registrarCaso(ServicioTCrearDTO servicio)
        {
           respuesta respuesta1 = new respuesta();
            try
            {
                await Task.Run(() => _ServicioTNegocio.crearServicioT(servicio));
                respuesta1.estadoRespuesta = true;
                respuesta1.mensajeRespuesta = "Se registró correctamente";
                return respuesta1;
            } catch (ExcepcionDatos ex)
            {
                respuesta1.estadoRespuesta =false;
                respuesta1.mensajeRespuesta = ex.Message;
                return respuesta1;
            }
         
        }

        [HttpDelete]
        [Route("eliminarCaso")]
        public bool eliminarServicio(int id, int tipo = 0)
        {
           return _ServicioTNegocio.eliminarServicio(id, tipo);
        }

    }
}
