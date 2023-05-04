using System.Text.Json.Serialization;

namespace Modelos
{
    public partial class UsuarioDTO
    {
        public int Idusuario { get; set; }

        public string Usuario1 { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int rolid { get; set; }

    }

}