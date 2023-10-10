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

 
        public string UsuarioDto { get; set; } = null!;


        public string PasswordDto { get; set; } = null!;

    }
}
