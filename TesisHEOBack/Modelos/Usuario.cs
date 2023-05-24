using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public int Idrol { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Rol IdrolNavigation { get; set; } = null!;
}
