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
            listaServicio = _dbContexto.Serviciotecnicos.Select(x => new ServicioTDTO()
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
                // Pendiente o solucionado
                Idestadoservicio = x.Idestadoservicio,

            }).Where(x => x.Idestadoservicio == estado).ToList();

            return listaServicio;
        }

        public async Task<dynamic> actualizarServicioT(ServicioTCrearDTO servicioT)
        {
            try
            {
                Serviciotecnico servicio = _dbContexto.Serviciotecnicos.First(i => i.Idproblemat == servicioT.idcaso);
                if (servicio != null)
                {
                    Tecnico tecnico = _dbContexto.Tecnicos.First(t => t.Idtecnico == servicio.Idtecnico);
                    if (servicio.Idtecnico != servicioT.Idtecnico )
                    {
                        tecnico.Casosnum = tecnico.Casosnum - 1;
                        Tecnico tecnico2 = _dbContexto.Tecnicos.First(t => t.Idtecnico == servicioT.Idtecnico);
                        tecnico2.Casosnum = tecnico2.Casosnum + 1;
                        _dbContexto.Update(tecnico);
                        _dbContexto.Update(tecnico2);
                    }
                    if (servicioT.Idestadoservicio == 2 && servicio.Idestadoservicio == 1 && tecnico.Casosnum > 0)
                    {                
                        tecnico.Casosnum = tecnico.Casosnum - 1;
                        _dbContexto.Update(tecnico);
                    }
                    if (servicioT.Idestadoservicio == 1 && servicio.Idestadoservicio == 2 && tecnico.Casosnum > 0)
                    {                     
                        tecnico.Casosnum = tecnico.Casosnum + 1;
                        _dbContexto.Update(tecnico);
                    }
                    if(servicioT.Idestadoservicio == 1 && servicio.Idestadoservicio == 2)
                    {
                        tecnico.Casosnum = tecnico.Casosnum + 1;
                        _dbContexto.Update(tecnico);
                    }


                    servicio.Descripcionserviciot = servicioT.Descripcionserviciot;
                    if (servicioT.Idtecnico != 0)
                        servicio.Idtecnico = servicioT.Idtecnico;
                    servicio.Idestadoservicio = servicioT.Idestadoservicio;
                    servicio.Descripcionserviciot = servicioT.Descripcionserviciot;
                    _dbContexto.Update(servicio);
                    await _dbContexto.SaveChangesAsync();
                    return true;
                }

                throw new ExcepcionDatos("Error capa datos");
            }
            catch (ExcepcionDatos ex)
            {
                throw new ExcepcionDatos("Error capa datos: " + ex);
            }
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
