using Datos;
using Microsoft.AspNetCore.Mvc;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Negocio
{
    public static class ClienteNegocio
    {
       public static List<ClienteDTO> listarClientes(int numero = 0, int numero2 = 0, string dato = "")
        {
            return ClienteDatos.listarClientes(numero, numero2, dato);
        }

        public static dynamic borrarCliente(int id)
        {
                return ClienteDatos.borrarClientes(id);
            
           
        }
    }
}
