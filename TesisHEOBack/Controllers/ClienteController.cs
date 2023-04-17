using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Text.Json.Serialization;
using System.Text.Json;
using TesisHEOBack.Modelos;
using Modelos.ModelosDTO; 

namespace TesisHEOBack.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class ClienteController : Controller
    {
      [HttpGet]
      [Route("ClientesList")]
        public dynamic listarCliente()
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

                return ClienteNegocio.listarClientes();
            
        }
    }
}
