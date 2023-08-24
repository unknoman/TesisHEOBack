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
                tecnico = x.IdtecnicoNavigation.Nombret + ' ' + x.IdtecnicoNavigation.Apellidot,
                // Pendiente o solucionado
                Idestadoservicio = x.Idestadoservicio,

            }).ToList();

            return listaServicio;
        }



        
    }
}
