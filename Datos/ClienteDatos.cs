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
                             Idcliente= c.Idcliente, // asignando c.idcliente a idcliente 
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

    
        public static dynamic borrarClientes(int id)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                Cliente cliente = db.Clientes.Find(id);
                if (cliente != null)
                {
                    db.Clientes.Remove(cliente);
                    return "Cliente " + cliente.Nombre + " " + cliente.Apellido + " Eliminado exitosamente";
                } else
                {
                    return "El cliente no se encontró en la base de datos";
                }

            }
              
            }    
    }
}
