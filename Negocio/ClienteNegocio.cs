﻿using Datos;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class ClienteNegocio
    {
        public static List<ClienteDTO> listarClientes()
        {
            return ClienteDatos.listarClientes();
        }
    }
}
