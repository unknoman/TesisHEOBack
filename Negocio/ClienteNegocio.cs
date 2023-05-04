using Datos;
using Microsoft.AspNetCore.Mvc;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Negocio
{
    public static class ClienteNegocio
    {
       public static List<ClienteDTO> listarClientes()
        {
            return ClienteDatos.listarClientes();
        }


        public static dynamic borrarCliente(int id)
        {
                return ClienteDatos.borrarClientes(id);
            
           
        }
    }
}
