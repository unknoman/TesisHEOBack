﻿using Microsoft.EntityFrameworkCore;
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

        public static List<ClienteDTO> listarClientes(int numero = 0, int numero2 = 0, int numero3 = 0, string dato = "")
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
                    }
             else if (numero2 == 3)
                {
                    if (numero == 1)
                    {
                        clientes = db.Clientes.Where(c => c.Nombre.StartsWith(dato) && c.Idestadoc == 3)
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
                        clientes = db.Clientes.Where(c => c.Apellido.StartsWith(dato) && c.Idestadoc == 3)
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
                        clientes = db.Clientes.Where(c => c.Dnic.StartsWith(dato) && c.Idestadoc == 3)
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
                        clientes = db.Clientes.Where(c => c.Idestadoc == 3)
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
                else




                {
                    return clientes;
                }




            }
        
        }


        public static dynamic crearCliente(clienteCrearDTO clientec)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                if(!String.IsNullOrEmpty(clientec.Nombre) || !String.IsNullOrEmpty(clientec.Apellido)  || !String.IsNullOrEmpty(clientec.Telefono) || !String.IsNullOrEmpty(clientec.Direccionc))
                {
                    Cliente cliente = new Cliente();
                    cliente.Nombre = clientec.Nombre;
                    cliente.Apellido = clientec.Apellido;
                    cliente.Dnic = clientec.Dnic;
                    cliente.Direccionc = clientec.Direccionc;
                    cliente.Telefono = clientec.Telefono;
                    cliente.Idservicio = null;
                    cliente.Idestadoc = 1;
                    cliente.Pagopendiente = 0;

                    db.Add(cliente);
                    db.SaveChanges();
                    return true;
                } else
                {
                    return false;
                }

            }
        }


        public static dynamic borrarClientes(int id)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                var cliente = db.Clientes.Include(c => c.Pagos).FirstOrDefault(c => c.Idcliente == id);
                if (cliente != null)
                {
                    bool puedeEliminar = cliente.Pagos.All(p => p.Idestadop == 2);
                    if (puedeEliminar)
                    {
                        db.RemoveRange(cliente.Pagos); // Eliminar los pagos asociados al cliente
                        db.Remove(cliente); // Eliminar el cliente
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                } else
                {
                    return false;
                }

              }
              
            }    
    }
}
