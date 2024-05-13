using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
    public class servicioDTO
    {

        public int Idservicio { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        public string Servicio1 { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        public string Subida { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido.")]
        public decimal Precio { get; set; }

        [Required (ErrorMessage = "Campo requerido.")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        public string Bajada { get; set; } = null!;

    }
}
