using Datos;
using Microsoft.AspNetCore.Mvc;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TesisHEOBack.Modelos;

namespace Negocio
{
    public static class ClienteNegocio
    {
       public static List<ClienteDTO> listarClientes(int numero = 0, int numero2 = 0, string dato = "")
        {
            return ClienteDatos.listarClientes(numero, numero2, dato);
        }


        public static List<ClienteDTO> listarClientesR(int numero = 0, int numero2 = 0, string dato = "")
        {
            return ClienteDatos.listarClientesR(numero, numero2, dato);
        }
     
        public static dynamic modificarCliente(clienteCrearDTO clientec)
        {
            return ClienteDatos.modificarCliente(clientec);
        }

        public static dynamic crearCliente(clienteCrearDTO clientec)
        {
           
            if (ClienteDatos.obtenerDNICantidad(clientec) == 0)
            {
                return ClienteDatos.crearCliente(clientec); 
            }
            return false;


        }
            public static dynamic borrarCliente(int id)
        {
                return ClienteDatos.borrarClientes(id);
            
   
        }


        public static List<clienteSimpleListDTO> listarClienteSimple(int estadoInstalado)
        {


            return ClienteDatos.listarClienteSimple(estadoInstalado);
            
        }
    }
}
