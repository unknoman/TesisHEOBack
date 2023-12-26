using System;
using System.Collections.Generic;
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

    public string Nombret { get; set; } = null!;

    public string Apellidot { get; set; } = null!;

    public int Casosnum { get; set; }

    public string Telefonot { get; set; } = null!;

    public int tecnicoEstado { get; set; }

}
}
