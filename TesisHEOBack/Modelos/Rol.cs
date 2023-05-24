using System;
using System.Collections.Generic;

namespace TesisHEOBack.Modelos;

public partial class Rol
{
    public int Idrol { get; set; }

    public string? Rol1 { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
