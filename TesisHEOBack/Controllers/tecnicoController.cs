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


        [HttpPatch]
        [Route("modificarTecnico")]
        public dynamic modificarTecnico(tecnicoModificarDTO dto)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                 if(string.IsNullOrEmpty(dto.Apellidot) || string.IsNullOrEmpty(dto.Nombret) || string.IsNullOrEmpty(dto.Telefonot) || dto.id == 0)
                {
                    return false;
                }
                 Tecnico tecnico = new Tecnico();
                tecnico = db.Tecnicos.FirstOrDefault(t => t.Idtecnico == dto.id);
                tecnico.Nombret = dto.Nombret;
                tecnico.Apellidot = dto.Apellidot;
                tecnico.Telefonot = dto.Telefonot;
                try
                {
                  db.Update(tecnico);
                  db.SaveChanges();
                    return true;
                } catch (Exception ex)
                {
                    return false;
                }
            
            }

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
        [HttpGet]
        [Route("listarTecnicoDisponible")]
        public dynamic listarTecnicosDisponibles()
        {
            return tecnicoNegocio.listarTecnicosDisponibles();
        }
    }
}







