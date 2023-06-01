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
    [Route("Clientes")]
    public class ClienteController : Controller
    {
        [HttpGet]
        [Route("ClientesList")]
        public dynamic listarCliente(int numero = 0, int numero2 = 0, int numero3 = 0, string? dato = null)
        {


            /*      using (TesisHeoContext db = new TesisHeoContext())   Consulta de icollect 
                {
                    var clientes = db.Clientes.Include(c => c.Direccions).Select(c => new {
                      c.Nombre,
                      c.Telefono,
                      Direcciones = c.Direccions.Select(d => d.Direccion1)
                    }).ToList();
                    return clientes;
                } 
            }  */

            return ClienteNegocio.listarClientes(numero, numero2, numero3, dato);

        }


        [HttpPut]
        [Route("ClientesCrear")]
        public dynamic crearCliente(clienteCrearDTO clientec)
        {
            return ClienteNegocio.crearCliente(clientec);
        }

        [HttpPatch]
        [Route("ClientesModificar")]
        public dynamic modificarCliente(clienteCrearDTO clientec)
        {
            return ClienteDatos.modificarCliente(clientec);
        }


        [HttpDelete]
        [Route("ClienteBorrar")]
        public dynamic borrarCliente(int id)
        {

            if (id != 0)
                return ClienteNegocio.borrarCliente(id);
            else
                return BadRequest("El cliente no se pudo borrar correctamente ya que no se ingresó un id");
        }

    }
}







