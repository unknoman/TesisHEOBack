using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Modelos.ModelosDTO
{
    public class ServicioTCrearDTO
    {
            public int? idcaso { get; set; }
            public int Idtecnico { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        public int Idcliente { get; set; }

            public int Idestadoservicio { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        public int Idtiposerviciot { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio.")]
        [MaxLength(51, ErrorMessage = "El campo no puede tener más de 50 caracteres.")]
        public string? Descripcionserviciot { get; set; }

            public DateTime Fechainicio { get; set; }

    }
}
