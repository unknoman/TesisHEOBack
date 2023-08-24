using Datos;
using Microsoft.Identity.Client;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ServicioTNegocio
    {
        private readonly ServicioTDatos _servicioDatos;
        public ServicioTNegocio(ServicioTDatos servicioTDatos) {
        _servicioDatos = servicioTDatos;
        }

        public List<ServicioTDTO> obtenerLista()
        {
            List<ServicioTDTO> listaServicioTDTO = new List<ServicioTDTO>();
            listaServicioTDTO = _servicioDatos.getServicioT();
            return listaServicioTDTO;
        }
    }
}
