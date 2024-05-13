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


        [HttpPost]
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
                    respuesta1.mensajeRespuesta = ex.Message;
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
                respuesta1.mensajeRespuesta = "El usuario fue eliminado correctamente";
                return respuesta1;

            } catch (ExcepcionDatos ex)
            {
                respuesta1.estadoRespuesta = false;
                respuesta1.mensajeRespuesta = ex.Message;
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
                    respuesta1.mensajeRespuesta = "El usuario fue actualizado correctamente";
                    return respuesta1;

                }
                catch (ExcepcionDatos ex)
                {
                    respuesta1.estadoRespuesta = false;
                    respuesta1.mensajeRespuesta = ex.Message;
                    return respuesta1;
                }
            }

        // esto tiene que ir en la capa de datos pero por poco tiempo lo pongo aca
        [HttpGet]
        [Route("listarRoles")]
        public dynamic listarRoles()
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                List<Rol> roles = db.Rols.ToList();
                return roles;
            }
         }

        }








    }

