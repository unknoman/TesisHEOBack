using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Datos
{
    public  class ClienteDatos
    {
        private readonly TesisHeoContext _dbContext;
        public ClienteDatos(TesisHeoContext dbContext)
        {
            _dbContext = dbContext;
        }




     public static List<ClienteDTO> listarClientes(int numero = 0, int numero2 = 0, string dato = "")
              {
                  using (TesisHeoContext db = new TesisHeoContext())
                  {
                      List<ClienteDTO> clientes = new List<ClienteDTO>();
                // Esto lo tengo que mejorar, lo hice con if para probar, pero lo podia hacer directamente con linq y mas simple
                      if (numero2 == 0)
                      {
                      if (numero == 1)
                      {
                          clientes = db.Clientes.Where(c => c.Nombre.StartsWith(dato))
                              .Select(c => new ClienteDTO
                              {
                                  Idcliente = c.Idcliente, // 
                                  Nombre = c.Nombre,
                                  Apellido = c.Apellido,
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
                                  Nombre = c.Nombre,
                                  Apellido = c.Apellido,
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
                                  Nombre = c.Nombre,
                                  Apellido = c.Apellido,
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
                       Nombre = c.Nombre,
                       Apellido = c.Apellido,
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
                                      Nombre = c.Nombre,
                                      Apellido = c.Apellido,
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
                                      Nombre = c.Nombre,
                                      Apellido = c.Apellido,
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
                                      Nombre = c.Nombre,
                                      Apellido = c.Apellido,
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
                                  Nombre = c.Nombre,
                                  Apellido = c.Apellido,
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
                                          Nombre = c.Nombre,
                                          Apellido = c.Apellido,
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
                                          Nombre = c.Nombre,
                                          Apellido = c.Apellido,
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
                                          Nombre = c.Nombre,
                                          Apellido =  c.Apellido,
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
                                      Nombre = c.Nombre,
                                      Apellido = c.Apellido,
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
                                      Nombre = c.Nombre,
                                      Apellido = c.Apellido,
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
                                      Nombre = c.Nombre,
                                      Apellido = c.Apellido,
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
                                      Nombre = c.Nombre,
                                      Apellido = c.Apellido,
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
                                  Nombre = c.Nombre,
                                  Apellido = c.Apellido,
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
        public static dynamic modificarCliente(clienteCrearDTO clientec)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                Cliente usuario = db.Clientes.FirstOrDefault(u => u.Idcliente == clientec.idCliente);
                if (!String.IsNullOrEmpty(usuario.Nombre))
                {
                    usuario.Nombre = clientec.Nombre;
                    usuario.Apellido = clientec.Apellido;
                    usuario.Dnic = clientec.Dnic;
                    if (clientec.idServicio != null || clientec.idServicio != 0)
                    {
                        usuario.Idservicio = clientec.idServicio;
                    }
                    usuario.Telefono = clientec.Telefono;
                    usuario.Direccionc = clientec.Direccionc;
                    db.Update(usuario);
                    db.SaveChanges();
                    return true;
                }
                else
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
                    bool puedeEliminar = cliente.Pagos.All(p => p.Idestadop == 2 || cliente.Idestadoc != 3 && cliente.Idestadoc != 2);
                    if (puedeEliminar)
                    {
                        db.RemoveRange(cliente.Pagos);
                        db.Remove(cliente); 
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