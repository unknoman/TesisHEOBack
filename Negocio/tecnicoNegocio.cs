using Datos;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class tecnicoNegocio
    {
        public static dynamic listarTecnico(int numero = 0, string? nombre = "")
        {
            return tecnicoDatos.listarTecnicos(numero, nombre);
        }


        public static dynamic listarTecnicosDisponibles()
        {
            return tecnicoDatos.listarTecnicosDisponibles();
        }

       

        public static dynamic crearTecnico(tecnicoDTO tecnico)
        {
            return tecnicoDatos.crearTecnico(tecnico);
        }

        public static dynamic eliminarTecnico (int id)
        {
            return tecnicoDatos.eliminarTecnico(id);
        }


    }
}
