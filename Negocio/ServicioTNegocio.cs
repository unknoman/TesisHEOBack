﻿using Datos;
using Datos.ServiciosDatos;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<dynamic> crearServicioT(ServicioTCrearDTO servicio)
        {
            if (servicio.Idestadoservicio == 0)
                throw new ExcepcionDatos("El idestadoservicio se encuentra vacio");
            if(servicio.Idcliente == 0)
                throw new ExcepcionDatos("el Idcliente se encuentra vacio");
            try
            {
              return await _servicioDatos.crearServicioT(servicio);
            } catch (ExcepcionDatos ex)
            {
                throw new ExcepcionDatos("Error", ex);
            }
        }
    }
}
