using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
    public class tecnicoModificarDTO
    {
        public int id { get; set; } = 0;

        [MaxLength(31, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        [Required(ErrorMessage = "El campo es requerido.")]
        public string Nombret { get; set; } = null!;

        [MaxLength(31, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        [Required(ErrorMessage = "El campo es requerido.")]
        public string Apellidot { get; set; } = null!;

        [MaxLength(31, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        [Required(ErrorMessage = "El campo es requerido.")]
        public string Telefonot { get; set;} = null!;
    }
}
