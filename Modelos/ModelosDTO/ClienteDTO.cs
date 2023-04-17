﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
    public partial class ClienteDTO
    {
        public int Idcliente { get; set; }

        public string Nombre { get; set; } = null!;

        public string Dnic { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Direccionc { get; set; } = null!;

        public decimal Pagopendiente { get; set; }

        public int Idestadoc { get; set; }

        public string estadoCliente { get; set; } = null!;
    }
}
