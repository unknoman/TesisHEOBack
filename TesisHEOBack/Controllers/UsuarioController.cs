using Datos.ServiciosDatos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Modelos;
using Modelos.ModelosDTO;
using Negocio;
using TesisHEOBack.Modelos;

namespace TesisHEOBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        respuesta respuesta1 = new respuesta();
        [HttpGet]
        [Route("listarUsuario")]
        public dynamic listarUsuario()
        {
            return UsuarioNegocio.listarUsuario();
        }


        [HttpPut]
        [Route("registrarUsuario")]
        public dynamic registrarUsuario(UsuarioDTO usuario)
        {

                try
                {
                    UsuarioNegocio.registrarUsuario(usuario);
                    respuesta1.estadoRespuesta = true;
                    respuesta1.mensajeRespuesta = "Se registro correctamente el usuario";
                    return respuesta1;

                } catch(ExcepcionDatos ex)
                {
                    respuesta1.estadoRespuesta = false;
                    respuesta1.mensajeRespuesta = ex.ToString();
                    return respuesta1;
                }

           
        }
        [HttpDelete]
        [Route("eliminarUsuario")]

        public dynamic eliminarUsuario(int id)
        {
            try
            {
                UsuarioNegocio.eliminarUsuario(id);
                respuesta1.estadoRespuesta = true;
                respuesta1.mensajeRespuesta = "Se elimino correctamente el usuario";
                return respuesta1;

            } catch (ExcepcionDatos ex)
            {
                respuesta1.estadoRespuesta = false;
                respuesta1.mensajeRespuesta = ex.ToString();
                return respuesta1;
            }
        }

        [HttpPatch]
        [Route("actualizarUsuario")]
        public dynamic actualizarUsuario(UsuarioModificarDTO usuario)
        {

                try
                {
                    UsuarioNegocio.actualizarUsuario(usuario);
                    respuesta1.estadoRespuesta = true;
                    respuesta1.mensajeRespuesta = "Se actualizo correctamente el usuario";
                    return respuesta1;

                }
                catch (ExcepcionDatos ex)
                {
                    respuesta1.estadoRespuesta = false;
                    respuesta1.mensajeRespuesta = ex.ToString();
                    return respuesta1;
                }
            }


        }








    }

