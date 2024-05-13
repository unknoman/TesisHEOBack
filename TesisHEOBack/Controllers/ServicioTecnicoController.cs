using Datos.ServiciosDatos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Modelos.Modelos;
using Modelos.ModelosDTO;
using Negocio;
using TesisHEOBack.Modelos;

namespace TesisHEOBack.Controllers
{
    [Route("api/ServicioT")]
    [ApiController]
    public class ServicioTecnicoController : Controller
    {
        private readonly ServicioTNegocio _ServicioTNegocio;
        private readonly TesisHeoContext _db;

        public ServicioTecnicoController(ServicioTNegocio servicioTNegocio, TesisHeoContext db) {
        _ServicioTNegocio = servicioTNegocio;
            _db = db;
        }

        [HttpGet]
        [Route("ServicioTI")]
        public dynamic listarServicioTI(int TI, int tipo)
        {
            List<ServicioTPlanilla> planillaList = new List<ServicioTPlanilla>();

            planillaList = _db.Serviciotecnicos.Where(c => c.Idtecnico == TI && c.Idtiposerviciot == tipo && c.Idestadoservicio == 1 && c.activo != false).Select(s => new ServicioTPlanilla
            {
                idCaso = s.Idproblemat,
                descripcion = s.Descripcionserviciot,
                nombreC = s.IdclienteNavigation.Nombre,
                apellidoC = s.IdclienteNavigation.Apellido,
                direccion = s.IdclienteNavigation.Direccionc,
                telefono = s.IdclienteNavigation.Telefono,
                tecnico = s.IdtecnicoNavigation.Nombret + s.IdtecnicoNavigation.Apellidot


            })
            .ToList();
            return planillaList;
        }


        [HttpGet]
        [Route("listarServicioT")]
        public dynamic listarServicioT(int estado)
        {
            return _ServicioTNegocio.obtenerLista(estado);
        }



        [HttpGet]
        [Route("listarServicioTR")]
        public dynamic getServicioTR(int estado)
        {
            return _ServicioTNegocio.getServicioTR(estado);
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


        [HttpPost]
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
