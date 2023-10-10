using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TesisHEOBack.Modelos;

public partial class Rol
{
    public int Idrol { get; set; }

    public string? Rol1 { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
