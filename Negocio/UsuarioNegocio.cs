using Datos.ServiciosDatos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using TesisHEOBack.Modelos;
using Datos;
using Modelos.ModelosDTO;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public static dynamic registrarUsuario(UsuarioDTO usuario)
        {
            if (!string.IsNullOrEmpty(usuario.PasswordDto) && !string.IsNullOrEmpty(usuario.UsuarioDto) && usuario.Idrol != 0)
                return UsuariosDatos.registrarUsuario(usuario);
            else
                throw new ExcepcionDatos("Verifica los campos");
        }

        public static List<Usuario> listarUsuario()
        {
            return UsuariosDatos.listarUsuario();
        }


        public static dynamic actualizarUsuario(UsuarioModificarDTO usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Password) && usuario.Idrol != 0)
                return UsuariosDatos.actualizarUsuario(usuario);
            else
                throw new ExcepcionDatos("Verifica los campos");
        }


        public static dynamic eliminarUsuario(int id)
        {
            return UsuariosDatos.eliminarUsuario(id);
        }


    }
}
