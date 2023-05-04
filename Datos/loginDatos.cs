using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Datos
{
    public class loginDatos
    {
         public static dynamic login(Usuario login)
          {
                  using (TesisHeoContext db = new TesisHeoContext())
                  {
                      var usuario = db.Usuarios.Where(usuario => usuario.Usuario1 == login.Usuario1 && usuario.Password == login.Password).FirstOrDefault();
                      return usuario;
                  }
              }

    }
}
