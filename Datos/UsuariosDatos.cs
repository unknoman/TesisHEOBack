using Datos.ServiciosDatos;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;
using Modelos.ModelosDTO;


// Esta todo mal estructurado pero como lo arranqué asi y por poco tiempo lo continuare de esta forma.
namespace Datos
{
    public class UsuariosDatos
    {

        public static dynamic registrarUsuario(UsuarioDTO usuario)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                try
                {

                    Usuario usuario1 = new Usuario();
                    usuario1.Usuario1 = usuario.usuario1;
                    usuario1.Password = usuario.password;
                    usuario1.Idrol = usuario.Idrol;
                    int usuarioCheck = db.Usuarios.Where(x => x.Usuario1 == usuario.usuario1).Count();
                    if (usuarioCheck < 1)
                    {
                        db.Usuarios.Add(usuario1);
                        db.SaveChanges();
                        return true;
                    } else
                    {
                        throw new ExcepcionDatos("Tenes que elegir un usuario que no este registrado");
                    }

                } catch (ExcepcionDatos ex)
                {
                    throw new ExcepcionDatos("Error", ex);
                }

            }
        }


    public static List<Usuario> listarUsuario()
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                List<Usuario> usuariosList = db.Usuarios.Include(u => u.IdrolNavigation).ToList();



                return usuariosList;
                
            }
         } 


        public static dynamic actualizarUsuario(UsuarioModificarDTO usuario)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                try
                {

                    if (usuario.Idusuario != 1)
                    {
                        Usuario usuario1 = new Usuario();
                        usuario1 = db.Usuarios.Where(c => c.Idusuario == usuario.Idusuario).FirstOrDefault();
                        usuario1.Password = usuario.Password;
                        usuario1.Idrol = usuario.Idrol;
                        db.Usuarios.Update(usuario1);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new ExcepcionDatos("El usuario administrador no se puede modificar");
                    }

                }
                catch (ExcepcionDatos ex)
                {
                    throw new ExcepcionDatos("Error", ex);
                }
            }
            }

        public static dynamic eliminarUsuario(int id)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                try
                {

                    Usuario? usuario1 = new Usuario();
                    usuario1 = db.Usuarios.Where(u => u.Idusuario == id).FirstOrDefault();
                    if (id != 1)
                    {
                        if (usuario1 != null)
                        {
                            db.Usuarios.Remove(usuario1);
                            int valor = db.SaveChanges();

                            if (valor > 0)
                                return true;
                            else
                                return false;
                        }
                        throw new ExcepcionDatos("No se encontró el usuario");

                    } else
                    {
                        throw new ExcepcionDatos("Error no se puede borrar el usuario administrador");
                    }

              }
                catch (ExcepcionDatos ex)
                {
                    throw new ExcepcionDatos("Error", ex);
                }
            }
        }
    }
}
