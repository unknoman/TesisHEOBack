using Microsoft.EntityFrameworkCore;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Datos
{
    public static class tecnicoDatos
    {

        public static dynamic crearTecnico(tecnicoDTO tecnicoc)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                if (!String.IsNullOrEmpty(tecnicoc.Nombret) || !String.IsNullOrEmpty(tecnicoc.Apellidot))
                {
                    Tecnico tecnico = new Tecnico();
                   tecnico.Nombret = tecnicoc.Nombret;
                    tecnico.Apellidot = tecnicoc.Apellidot;
                    tecnico.Telefonot = tecnicoc.Telefonot;
                    tecnico.Casosnum = 0;
                    tecnico.Idestado = 1;

                    db.Add(tecnico);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }



        public static dynamic eliminarTecnico(int id)
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                if (id != 0)
                {
                    var tecnico = db.Tecnicos.Include(c => c.Serviciotecnicos).FirstOrDefault(c => c.Idtecnico == id);
                    tecnico.Idestado = 3;
                    db.Update(tecnico);
                   int valor = db.SaveChanges();
                    if(valor >0)
                    return true;
                }

                return false;
            }
        }

        public static List<tecnicoDTO> listarTecnicos(int numero = 0, string? dato = "")
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                List<tecnicoDTO> tecnicos = new List<tecnicoDTO>();
                IQueryable<Tecnico> query = db.Tecnicos.Where(c => c.Nombret.StartsWith(dato) || c.Apellidot.StartsWith(dato) || c.Nombret.StartsWith(dato));

                if (numero == 0)
                {
                    query = query.Where(c=> c.Idestado != 3);
                }
                else if (numero == 1)
                {
                    query = query.Where(c => c.Idestado == 1);
                }
                else if (numero == 2)
                {
                    query = query.Where(c => c.Idestado == 2);
                }

                tecnicos = query.Select(c => new tecnicoDTO
                {
                    Idtecnico = c.Idtecnico,
                    Nombret = c.Nombret,
                    Apellidot = c.Apellidot,
                    Casosnum = c.Casosnum,
                    Telefonot = c.Telefonot
                }).OrderByDescending(t => t.Idtecnico == 0 ? int.MaxValue : t.Idtecnico) // Ordena primero los elementos con Idtecnico igual a 0
                .ToList();

                return tecnicos;
            }
        }


        public static List<tecnicoDTO> listarTecnicosDisponibles()
        {
            using (TesisHeoContext db = new TesisHeoContext())
            {
                List<tecnicoDTO> tecnicos = new List<tecnicoDTO>();


                tecnicos = db.Tecnicos.Where(c => c.Casosnum < 5 && c.Idestado != 3 && c.Idtecnico != 0).Select(c => new tecnicoDTO
                {
                    Idtecnico = c.Idtecnico,
                    Nombret = c.Nombret,
                    Apellidot = c.Apellidot,
                    Casosnum = c.Casosnum,
                    Telefonot = c.Telefonot,
                    tecnicoEstado = c.Idestado
                })
                .ToList();

                return tecnicos;
            }
        }

    }


}

