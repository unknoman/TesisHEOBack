using Microsoft.IdentityModel.Tokens;
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
        public static List<ClienteDTO> listarClientes(int numero = 0, int numero2 = 0, string dato = "")
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                List<ClienteDTO> clientes = new List<ClienteDTO>();
                if (numero2 == 0)
                {
                if (numero == 1)
                {
                    clientes = db.Clientes.Where(c => c.Nombre.StartsWith(dato))
                        .Select(c => new ClienteDTO
                        {
                            Idcliente = c.Idcliente, // 
                            Nombre = c.Nombre + " " + c.Apellido,
                            Dnic = c.Dnic,
                            Direccionc = c.Direccionc,
                            Telefono = c.Telefono,
                            Idestadoc = c.Idestadoc,
                            estadoCliente = c.IdestadocNavigation.Estadocliente1,
                            servicio = c.IdservicioNavigation.Servicio1
                        })
                        .ToList();
                    return clientes;
                }
                else if (numero == 2)
                {
                    clientes = db.Clientes.Where(c => c.Apellido.StartsWith(dato))
                        .Select(c => new ClienteDTO
                        {
                            Idcliente = c.Idcliente, // 
                            Nombre = c.Nombre + " " + c.Apellido,
                            Dnic = c.Dnic,
                            Direccionc = c.Direccionc,
                            Telefono = c.Telefono,
                            Idestadoc = c.Idestadoc,
                            estadoCliente = c.IdestadocNavigation.Estadocliente1,
                            servicio = c.IdservicioNavigation.Servicio1
                        })
                        .ToList();
                    return clientes;
                }
                else if (numero == 3)
                {
                    clientes = db.Clientes.Where(c => c.Dnic.StartsWith(dato))
                        .Select(c => new ClienteDTO
                        {
                            Idcliente = c.Idcliente, // 
                            Nombre = c.Nombre + " " + c.Apellido,
                            Dnic = c.Dnic,
                            Direccionc = c.Direccionc,
                            Telefono = c.Telefono,
                            Idestadoc = c.Idestadoc,
                            estadoCliente = c.IdestadocNavigation.Estadocliente1,
                            servicio = c.IdservicioNavigation.Servicio1
                        })
                        .ToList();
                    return clientes;
                } else if (numero == 0 && string.IsNullOrEmpty(dato))
                    clientes = db.Clientes
                    .Select(c => new ClienteDTO
                    {
                       Idcliente = c.Idcliente, // 
                 Nombre = c.Nombre + " " + c.Apellido,
                 Dnic = c.Dnic,
                 Direccionc = c.Direccionc,
                 Telefono = c.Telefono,
                 Idestadoc = c.Idestadoc,
                 estadoCliente = c.IdestadocNavigation.Estadocliente1,
                 servicio = c.IdservicioNavigation.Servicio1
                  })
                    .ToList();
                return clientes;
                } else if (numero2 == 1) // numero 2 filtro 
                {
                    if (numero == 1)
                    {
                        clientes = db.Clientes.Where(c => c.Nombre.StartsWith(dato) && c.Idestadoc == 1)
                            .Select(c => new ClienteDTO
                            {
                                Idcliente = c.Idcliente, // 
                                Nombre = c.Nombre + " " + c.Apellido,
                                Dnic = c.Dnic,
                                Direccionc = c.Direccionc,
                                Telefono = c.Telefono,
                                Idestadoc = c.Idestadoc,
                                estadoCliente = c.IdestadocNavigation.Estadocliente1,
                                servicio = c.IdservicioNavigation.Servicio1
                            })
                            .ToList();
                        return clientes;
                    }
                    else if (numero == 2)
                    {
                        clientes = db.Clientes.Where(c => c.Apellido.StartsWith(dato) && c.Idestadoc == 1)
                            .Select(c => new ClienteDTO
                            {
                                Idcliente = c.Idcliente, // 
                                Nombre = c.Nombre + " " + c.Apellido,
                                Dnic = c.Dnic,
                                Direccionc = c.Direccionc,
                                Telefono = c.Telefono,
                                Idestadoc = c.Idestadoc,
                                estadoCliente = c.IdestadocNavigation.Estadocliente1,
                                servicio = c.IdservicioNavigation.Servicio1
                            })
                            .ToList();
                        return clientes;
                    }
                    else if (numero == 3)
                    {
                        clientes = db.Clientes.Where(c => c.Dnic.StartsWith(dato) && c.Idestadoc == 1)
                            .Select(c => new ClienteDTO
                            {
                                Idcliente = c.Idcliente, // 
                                Nombre = c.Nombre + " " + c.Apellido,
                                Dnic = c.Dnic,
                                Direccionc = c.Direccionc,
                                Telefono = c.Telefono,
                                Idestadoc = c.Idestadoc,
                                estadoCliente = c.IdestadocNavigation.Estadocliente1,
                                servicio = c.IdservicioNavigation.Servicio1
                            })
                            .ToList();
                        return clientes;
                    }
                    else if (numero == 0 && string.IsNullOrEmpty(dato))
                        clientes = db.Clientes.Where(c => c.Idestadoc == 1)
                        .Select(c => new ClienteDTO
                        {
                            Idcliente = c.Idcliente, // 
                            Nombre = c.Nombre + " " + c.Apellido,
                            Dnic = c.Dnic,
                            Direccionc = c.Direccionc,
                            Telefono = c.Telefono,
                            Idestadoc = c.Idestadoc,
                            estadoCliente = c.IdestadocNavigation.Estadocliente1,
                            servicio = c.IdservicioNavigation.Servicio1
                        })
                        .ToList();
                    return clientes;
                } 
                    else if (numero2 == 2)
                    {
                        if (numero == 1)
                        {
                            clientes = db.Clientes.Where(c => c.Nombre.StartsWith(dato) && c.Idestadoc == 2)
                                .Select(c => new ClienteDTO
                                {
                                    Idcliente = c.Idcliente, // 
                                    Nombre = c.Nombre + " " + c.Apellido,
                                    Dnic = c.Dnic,
                                    Direccionc = c.Direccionc,
                                    Telefono = c.Telefono,
                                    Idestadoc = c.Idestadoc,
                                    estadoCliente = c.IdestadocNavigation.Estadocliente1,
                                    servicio = c.IdservicioNavigation.Servicio1
                                })
                                .ToList();
                            return clientes;
                        }
                        else if (numero == 2)
                        {
                            clientes = db.Clientes.Where(c => c.Apellido.StartsWith(dato) && c.Idestadoc == 2)
                                .Select(c => new ClienteDTO
                                {
                                    Idcliente = c.Idcliente, // 
                                    Nombre = c.Nombre + " " + c.Apellido,
                                    Dnic = c.Dnic,
                                    Direccionc = c.Direccionc,
                                    Telefono = c.Telefono,
                                    Idestadoc = c.Idestadoc,
                                    estadoCliente = c.IdestadocNavigation.Estadocliente1,
                                    servicio = c.IdservicioNavigation.Servicio1
                                })
                                .ToList();
                            return clientes;
                        }
                        else if (numero == 3)
                        {
                            clientes = db.Clientes.Where(c => c.Dnic.StartsWith(dato) && c.Idestadoc == 2)
                                .Select(c => new ClienteDTO
                                {
                                    Idcliente = c.Idcliente, // 
                                    Nombre = c.Nombre + " " + c.Apellido,
                                    Dnic = c.Dnic,
                                    Direccionc = c.Direccionc,
                                    Telefono = c.Telefono,
                                    Idestadoc = c.Idestadoc,
                                    estadoCliente = c.IdestadocNavigation.Estadocliente1,
                                    servicio = c.IdservicioNavigation.Servicio1
                                })
                                .ToList();
                            return clientes;
                        }
                        else if (numero == 0 && string.IsNullOrEmpty(dato))
                            clientes = db.Clientes.Where(c => c.Idestadoc == 2)
                            .Select(c => new ClienteDTO
                            {
                                Idcliente = c.Idcliente, // 
                                Nombre = c.Nombre + " " + c.Apellido,
                                Dnic = c.Dnic,
                                Direccionc = c.Direccionc,
                                Telefono = c.Telefono,
                                Idestadoc = c.Idestadoc,
                                estadoCliente = c.IdestadocNavigation.Estadocliente1,
                                servicio = c.IdservicioNavigation.Servicio1
                            })
                            .ToList();
                        return clientes;
                    } else
                {
                    return clientes;
                }




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
