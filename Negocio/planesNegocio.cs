using Datos;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Negocio
{
    public static class planesNegocio
    {
        public static dynamic listarPlanes()
        {
            return planesDatos.listarPlanes();
        }

        public static dynamic eliminarPlan(int id)
        {
            return planesDatos.eliminarPlan(id);
        }

        public static dynamic actualizarPlan(servicioDTO plan)
        {
            return planesDatos.actualizarPlan(plan);
        }
            public static dynamic crearPlan(servicioDTO plan)
        {
            if(!String.IsNullOrEmpty(plan.Servicio1.ToString()) && !String.IsNullOrEmpty(plan.Bajada) && !String.IsNullOrEmpty(plan.Subida) && plan.Idservicio == 0)
            {
                return planesDatos.crearPlan(plan);
            } else
            {
                return "0";
                
            }
        }
    }
}
