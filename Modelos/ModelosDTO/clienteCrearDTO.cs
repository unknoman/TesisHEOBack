using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Modelos.ModelosDTO
{
   public class clienteCrearDTO
    {
        public int idCliente { get; set; } = 0 ;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [MaxLength(31, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [MaxLength(31, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [MaxLength(11, ErrorMessage = "El campo no puede tener más de 11 caracteres.")]
        public string Dnic { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [MaxLength(12, ErrorMessage = "El campo no puede tener más de 12 caracteres.")]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [MaxLength(51, ErrorMessage = "El campo no puede tener más de 50 caracteres.")]
        public string Direccionc { get; set; } = null!;

        public int? idServicio { get; set; } = null;

    }
}
