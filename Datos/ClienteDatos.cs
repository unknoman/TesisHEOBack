using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Datos
{
    public static class ClienteDatos
    {

        public static List<ClienteDTO> listarClientes()
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                List<ClienteDTO> clientes = new List<ClienteDTO>();


                clientes = db.Clientes
                    .Select(c => new ClienteDTO
                    {
                        Idcliente= c.Idcliente,
                        Nombre = c.Nombre + " " + c.Apellido,
                        Dnic = c.Dnic,
                        Direccionc = c.Direccionc,
                        Telefono = c.Telefono,
                        Idestadoc = c.Idestadoc,
                        estadoCliente = c.IdestadocNavigation.Estadocliente1
                    })
                    .ToList();
                return clientes;
            }
        }
    }
}
