using Datos.ServiciosDatos;
using Microsoft.EntityFrameworkCore;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Datos
{
   public class ServicioTDatos
    {

        // Uso inyeccion de dependencias 
    private readonly TesisHeoContext _dbContexto;

        // constructor
    public ServicioTDatos(TesisHeoContext dbcontexto) {
            _dbContexto = dbcontexto;
        }
        // ----- Metodos datos ServicioT


        public List<ServicioTDTO> getServicioT(int estado)
        {
            List<ServicioTDTO> listaServicio = new List<ServicioTDTO>();
            listaServicio = _dbContexto.Serviciotecnicos.Where(s => s.activo != false).Select(x => new ServicioTDTO()
            {
                Idproblemat = x.Idproblemat,
                Idtiposerviciot = x.Idtiposerviciot,
                clienteN = x.IdclienteNavigation.Nombre,
                clienteA = x.IdclienteNavigation.Apellido,
                dnic = x.IdclienteNavigation.Dnic,
                Fechainicio = x.Fechainicio,
                Descripcionserviciot = x.Descripcionserviciot,
                direccion = _dbContexto.Clientes.Where(c => c.Idcliente == x.Idcliente).Select(c => c.Direccionc).First(),
                tecnico = x.IdtecnicoNavigation.Nombret + ' ' + x.IdtecnicoNavigation.Apellidot,
                idtecnico = x.IdtecnicoNavigation.Idtecnico,
                // Pendiente o solucionado
                Idestadoservicio = x.Idestadoservicio,

            }).Where(x => x.Idestadoservicio == estado & x.Idtiposerviciot == 2).ToList();

            return listaServicio;
        }


        public List<ServicioTDTO> getServicioTR(int estado)
        {
            List<ServicioTDTO> listaServicio = new List<ServicioTDTO>();
            listaServicio = _dbContexto.Serviciotecnicos.Where(s => s.activo != false).Select(x => new ServicioTDTO()
            {
                Idproblemat = x.Idproblemat,
                Idtiposerviciot = x.Idtiposerviciot,
                clienteN = x.IdclienteNavigation.Nombre,
                clienteA = x.IdclienteNavigation.Apellido,
                dnic = x.IdclienteNavigation.Dnic,
                Fechainicio = x.Fechainicio,
                Descripcionserviciot = x.Descripcionserviciot,
                direccion = _dbContexto.Clientes.Where(c => c.Idcliente == x.Idcliente).Select(c => c.Direccionc).First(),
                tecnico = x.IdtecnicoNavigation.Nombret + ' ' + x.IdtecnicoNavigation.Apellidot,
                idtecnico = x.IdtecnicoNavigation.Idtecnico,
                // Pendiente o solucionado
                Idestadoservicio = x.Idestadoservicio,

            }).Where(x => x.Idestadoservicio == estado & x.Idtiposerviciot == 1).ToList();

            return listaServicio;
        }
        private static readonly object _lock = new object();

        public dynamic actualizarServicioT(ServicioTCrearDTO servicioT)
        {

            lock (_lock)
             
            {
                int bandera = 0;

                Serviciotecnico servicio = _dbContexto.Serviciotecnicos.First(i => i.Idproblemat == servicioT.idcaso);
                Tecnico tecnico = _dbContexto.Tecnicos.First(t => t.Idtecnico == servicio.Idtecnico);
                Cliente cliente = _dbContexto.Clientes.First(c => c.Idcliente == servicio.Idcliente);
                // aca se restan o se suman dependiendo si el tecnico tiene servicios tecnicos que atender nuevos o no 
                if (servicio.Idtecnico != servicioT.Idtecnico && servicio.Idestadoservicio != 2)
                         {
                             if(tecnico.Casosnum > 0)
                    {
                        tecnico.Casosnum = tecnico.Casosnum - 1;
                        bandera = 1;
                    }

                             if(servicioT.Idestadoservicio != 2)
                              {
                               Tecnico tecnico2 = _dbContexto.Tecnicos.First(t => t.Idtecnico == servicioT.Idtecnico);
                               tecnico2.Casosnum = tecnico2.Casosnum + 1;
                               _dbContexto.Update(tecnico);
                               _dbContexto.Update(tecnico2);
                    }
              
                    
                         }
                        if (servicioT.Idestadoservicio == 2 && servicio.Idestadoservicio == 1 && bandera == 0)
                         {        
                           
                          tecnico.Casosnum = tecnico.Casosnum - 1;
                    servicio.Descripcionserviciot = servicioT.Descripcionserviciot;
                    servicio.Idtecnico = servicioT.Idtecnico;
                    servicio.Idestadoservicio = servicioT.Idestadoservicio;
                    servicio.Descripcionserviciot = servicioT.Descripcionserviciot;
                    cliente.Instalado = 1;
                    _dbContexto.Update(tecnico);
                          _dbContexto.SaveChanges();
                          return true;
                         } 
                         if (servicioT.Idestadoservicio == 1 && servicio.Idestadoservicio == 2)
                         {                     
                             tecnico.Casosnum = tecnico.Casosnum + 1;
                             _dbContexto.Update(tecnico);
                         }           
                
                    // si tipo de servicio es igual a instalacion y estado de servicio paso a solucionado el cliente se cambia a instalado

     
                    servicio.Descripcionserviciot = servicioT.Descripcionserviciot;
                    servicio.Idtecnico = servicioT.Idtecnico; 
                    servicio.Idestadoservicio = servicioT.Idestadoservicio;
                    servicio.Descripcionserviciot = servicioT.Descripcionserviciot;
                    _dbContexto.Update(servicio);

                if (servicioT.Idtiposerviciot == 2 && servicio.Idestadoservicio == 2)
                {
                    cliente.Instalado = 1;
                    _dbContexto.Update(cliente);

                }
                else if (servicioT.Idtiposerviciot == 2 && servicio.Idestadoservicio == 1)
                {
                    cliente.Instalado = 0;
                    _dbContexto.Update(cliente);


                }
                _dbContexto.SaveChanges();
                    
                
            }

            return true;
        }

/*
        public bool getEstadoServicioT(int id)
        {

            Serviciotecnico servicioTe = _dbContexto.Serviciotecnicos.Where(s => s.Idproblemat == id).FirstOrDefault();
            if (servicioTe.Idestadoservicio == 3)
                return false;
            return true;
        }
 */

        public bool eliminarServicioT(int id, int tipo)
        {
            Serviciotecnico? servicioTe = _dbContexto.Serviciotecnicos.Where(i => i.Idproblemat == id).FirstOrDefault();
            if(servicioTe?.Idestadoservicio == 1)
            {
                var tecnico = _dbContexto.Tecnicos.Where(i => i.Idtecnico == servicioTe.Idtecnico).FirstOrDefault();
                if(tecnico?.Casosnum > 0)
                {
                    tecnico.Casosnum = tecnico.Casosnum - 1;
                    _dbContexto.Update(tecnico);
                }
            }
            if (tipo == 1) // 1 es cobranza 
            {
                if (servicioTe != null)
                {
                    var socio = _dbContexto.Clientes.Where(i => i.Idcliente == servicioTe.Idcliente).FirstOrDefault();
                    if (socio != null)
                    {
                        socio.Instalado = 0;
                        _dbContexto.Update(socio);
                    }
                }
            }
            if(servicioTe != null)
            {
                servicioTe.activo = false;
                _dbContexto.Update(servicioTe);
            }
             

          int valor = _dbContexto.SaveChanges();
            if(valor > 0)
            {
                return true;
            } 
            return false;
        }
        public async Task<dynamic> crearServicioT(ServicioTCrearDTO servicioDTO)
        {
            try
            {
                Serviciotecnico servicio = new Serviciotecnico();
                servicio.Idcliente = servicioDTO.Idcliente;
                servicio.Idtecnico = servicioDTO.Idtecnico;
                servicio.Idestadoservicio = servicioDTO.Idestadoservicio;
                servicio.Descripcionserviciot = servicioDTO.Descripcionserviciot;
                servicio.Idtiposerviciot = servicioDTO.Idtiposerviciot;
                servicio.Fechainicio = servicioDTO.Fechainicio;
                if (servicio.Idestadoservicio == 1)
                {
 
                    Tecnico tecnico = _dbContexto.Tecnicos.First(t => t.Idtecnico == servicio.Idtecnico);
                    tecnico.Casosnum = tecnico.Casosnum + 1; 
                    _dbContexto.Update(tecnico);
                }
                _dbContexto.Add(servicio);
                await _dbContexto.SaveChangesAsync();
                return true;
            } catch(ExcepcionDatos ex)
            {
               throw new ExcepcionDatos("Error", ex);
            }
        }
    }
}
