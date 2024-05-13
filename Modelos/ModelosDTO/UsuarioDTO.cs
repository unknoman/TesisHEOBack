using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Modelos.ModelosDTO
{
    public class UsuarioDTO
    {

        public int Idrol { get; set; }


        [MaxLength(51, ErrorMessage = "El campo no puede tener más de 51 caracteres.")]
        [Required(ErrorMessage = "El campo es requerido.")]
        public string usuario1 { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "El campo no puede tener más de 100 caracteres.")]
        [Required(ErrorMessage = "El campo es requerido.")]
        public string password { get; set; } = null!;

    }
}
