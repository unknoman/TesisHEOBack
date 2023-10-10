using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ModelosDTO
{
    public class UsuarioModificarDTO
    {
        public int Idusuario { get; set; }

        public int Idrol { get; set; }


        public string Password { get; set; } = null!;
    }
}
