using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
    public class tecnicoDTO
    {
    public int Idtecnico { get; set; }

    public int Idestado { get; set; }
   public string? estado { get; set; }

        [MaxLength(31, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        [Required(ErrorMessage = "El campo es requerido.")]
        public string Nombret { get; set; } = null!;

        [MaxLength(31, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        [Required(ErrorMessage = "El campo es requerido.")]
        public string Apellidot { get; set; } = null!;

    public int Casosnum { get; set; }

        [MaxLength(31, ErrorMessage = "El campo no puede tener más de 31 caracteres.")]
        [Required(ErrorMessage = "El campo es requerido.")]
        public string Telefonot { get; set; } = null!;

    public int tecnicoEstado { get; set; }

}
}
