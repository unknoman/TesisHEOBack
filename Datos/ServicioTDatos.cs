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


        public List<ServicioTDTO> getServicioT()
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
                tecnico = x.IdtecnicoNavigation.Nombret + ' ' + x.IdtecnicoNavigation.Apellidot,
                // Pendiente o solucionado
                Idestadoservicio = x.Idestadoservicio,

            }).Where(x => x.Idestadoservicio == 1).ToList();

            return listaServicio;
        }

        public async Task<dynamic> actualizarServicioT(ServicioTCrearDTO servicioT)
        {
            try
            {
                Serviciotecnico servicio = _dbContexto.Serviciotecnicos.FirstOrDefault(i => i.Idproblemat == servicioT.idcaso);
                if (servicio != null)
                {
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
                if (servicioDTO.Idtecnico != 0)
                    servicio.Idtecnico = servicioDTO.Idtecnico;
                servicio.Idestadoservicio = servicioDTO.Idestadoservicio;
                servicio.Descripcionserviciot = servicioDTO.Descripcionserviciot;
                servicio.Idtiposerviciot = servicioDTO.Idtiposerviciot;
                servicio.Fechainicio = servicioDTO.Fechainicio;
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
