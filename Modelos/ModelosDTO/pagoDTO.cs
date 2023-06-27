using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Modelos.ModelosDTO
{
    public class pagoDTO
    {
        public int Idfactura { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Fechavencimiento { get; set; }

        public DateTime? Fechapagado { get; set; }

        public string? servicio { get; set; }

        public decimal Preciototal { get; set; }

        public int idestadop { get; set; }

        public string? estado { get; set; }
    }
}
