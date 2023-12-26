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


        public static List<clienteSimpleListDTO> listarClienteSimple(int estadoInstalado)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                List<clienteSimpleListDTO> lista = new List<clienteSimpleListDTO>();

                lista = db.Clientes.Where(c => c.Instalado == estadoInstalado && c.Idestadoc != 1001).Select(c => new clienteSimpleListDTO
                {
                    Idcliente = c.Idcliente,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Pagopendiente = c.Pagopendiente,
                    Instalado = c.Instalado,
                    Dnic = c.Dnic
                }).ToList();
                return lista;
            }
        }

        public static void actualizarClientes()
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                // Obtengo la lista de los clientes originales con sus pagos
                List<Cliente> clientesOriginales = db.Clientes.Include(c => c.Pagos).ToList();



                foreach (Cliente cliente in clientesOriginales)
                {
                    bool tienePagosVencidos = false;

                    foreach (Pago pago in cliente.Pagos)
                    {
                        // Verificar si el pago está vencido
                        if (pago.Fechavencimiento < pago.Fechapagado || pago.Fechapagado == null && pago.Idestadop != 3)
                        {
                            tienePagosVencidos = true;
                            break; 
                        }
                    }

                    // Actualizar el estado del cliente si tiene pagos vencidos
                    if (tienePagosVencidos)
                    {
                        cliente.Idestadoc = 2;
                    }
                }

                // Guardar los cambios en la base de datos
                db.SaveChanges();
            }
        }

/*
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
*/

       public static List<ClienteDTO> listarClientes(int numero = 0, int numero2 = 0, string dato = "")
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                var query = db.Clientes.Select(c => new ClienteDTO
                {
                    Idcliente = c.Idcliente,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Dnic = c.Dnic,
                    Direccionc = c.Direccionc,
                    Telefono = c.Telefono,
                    Idestadoc = c.Idestadoc,
                    estadoCliente = c.IdestadocNavigation.Estadocliente1,
                    servicio = c.IdservicioNavigation.Servicio1
                }).Where(c => c.Idestadoc != 1001);

                if (!string.IsNullOrEmpty(dato))
                {
                    switch (numero)
                    {
                        case 1:
                            query = query.Where(c => c.Nombre.StartsWith(dato));
                            break;
                        case 2:
                            query = query.Where(c => c.Apellido.StartsWith(dato));
                            break;
                        case 3:
                            query = query.Where(c => c.Dnic.StartsWith(dato));
                            break;
                        default:
                            break;
                    }
                }

                if (numero2 > 0)
                {
                    query = query.Where(c => c.Idestadoc == numero2);
                }

                return query.ToList();
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
                    cliente.Instalado = 0;
                    cliente.Idservicio = 1;
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
                Cliente usuario = db.Clientes.Include(c => c.IdservicioNavigation).FirstOrDefault(u => u.Idcliente == clientec.idCliente);

                if (usuario != null)
                {
                    usuario.Nombre = clientec.Nombre;
                    usuario.Apellido = clientec.Apellido;
                    usuario.Dnic = clientec.Dnic;
                    usuario.Telefono = clientec.Telefono;
                    usuario.Direccionc = clientec.Direccionc;

                    if (clientec.idServicio != null && clientec.idServicio != 0)
                    {
                        int idServicioAnterior = usuario.Idservicio ?? 0; // Guarda el valor anterior
                        usuario.Idservicio = clientec.idServicio;

                        if (idServicioAnterior != clientec.idServicio)
                        {
                            // Obtener el nombre y precio del servicio actual
                            Servicio servicioActual = db.Servicios.FirstOrDefault(s => s.Idservicio == clientec.idServicio);

                            // Obtener el nombre y precio del servicio anterior
                            Servicio servicioAnterior = db.Servicios.FirstOrDefault(s => s.Idservicio == idServicioAnterior);

                            if (servicioActual != null && servicioAnterior != null)
                            {
                                // Insertar un nuevo registro en la tabla Pago
                                Pago nuevoPago = new Pago
                                {
                                    Idcliente = usuario.Idcliente,
                                    Idestadop = 1,
                                    Fecha = DateTime.Now.Date,
                                    Fechavencimiento = DateTime.Now.AddDays(10),
                                    Serviciop = servicioActual.Servicio1,
                                    Preciototal = servicioActual.Precio 
                                };
                                db.Pagos.Add(nuevoPago);

                                // Actualizar el estado del cliente a 3 (pendiente)
                                usuario.Idestadoc = 3;
                            }
                        }
                    }

                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public static dynamic obtenerDNICantidad(clienteCrearDTO clientec)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                return db.Clientes.Count(c => c.Dnic == clientec.Dnic);
            }
        }

        public static dynamic borrarClientes(int id)
              {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                var cliente = db.Clientes.Include(c => c.Pagos).Include(c=> c.Serviciotecnicos).FirstOrDefault(c => c.Idcliente == id);
                if (cliente != null)
                {
                    bool puedeEliminar = cliente.Pagos.All(p => p.Idestadop == 2);
                    if (puedeEliminar)
                    {
                        cliente.Idestadoc = 1001;
                        db.Update(cliente);
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