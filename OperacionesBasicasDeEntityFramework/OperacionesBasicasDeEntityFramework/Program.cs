using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesBasicasDeEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EntityTestEntities())
            {
                var facultades = db.Facultad.ToList();
                var IdDeFacultades = facultades.Select(x => x.Id).ToList();
                var cursosDeLasFacultades = db.Curso.Where(x => IdDeFacultades.Contains(x.Id));


                facultades.ForEach(facultad =>
                {
                    Console.WriteLine(facultad.Nombre);
                    facultad.Curso.ToList().ForEach(curso =>
                    {
                        Console.WriteLine($"    Curso : {curso.Nombre}");
                    });
                });
                Console.ReadKey();
            }
        }

        private void CrearFacultades()
        {
            using (var db = new EntityTestEntities())
            {
                db.Facultad.Add(new Facultad()
                {
                    Nombre = "Matematicas"
                });
                db.Facultad.Add(new Facultad()
                {
                    Nombre = "Fisica"
                });
                db.Facultad.Add(new Facultad()
                {
                    Nombre = "Ciencias de la Computacion"
                });
                db.SaveChanges();
            }
        }

        private void CrearCursosConsultandoLasFacultadesPrimero()
        {
            using (var db = new EntityTestEntities())
            {
                var matematicas = db.Facultad.Find(1);
                matematicas.Curso.Add(new Curso()
                {
                    Nombre = "Calculo 1"
                });
                matematicas.Curso.Add(new Curso()
                {
                    Nombre = "Calculo 2"
                });
                matematicas.Curso.Add(new Curso()
                {
                    Nombre = "Geometria Analitica"
                });
                matematicas.Curso.Add(new Curso()
                {
                    Nombre = "Calculo en varias variables"
                });
                matematicas.Curso.Add(new Curso()
                {
                    Nombre = "Algebra lineal"
                });

                var fisica = db.Facultad.First(x => x.Nombre.StartsWith("Fis"));
                fisica.Curso.Add(new Curso()
                {
                    Nombre = "Fisica 1"
                });
                fisica.Curso.Add(new Curso()
                {
                    Nombre = "Fisica 2"
                });

                var cienciasDeLaComputacion = db.Facultad.Find(3);
                db.Curso.Add(new Curso()
                {
                    Nombre = "Estuctura de datos",
                    FacultadId = cienciasDeLaComputacion.Id
                });
                db.Curso.Add(new Curso()
                {
                    Nombre = "Compiladores",
                    Facultad = cienciasDeLaComputacion
                });

                db.SaveChanges();
            }
        }

        private void CrearCursosHaciendoAttachAlaFacultad()
        {
            using (var db = new EntityTestEntities())
            {
                var matematicas = new Facultad()
                {
                    Id = 1,
                    Nombre = "Matematicas"
                };
                db.Facultad.Attach(matematicas);
                db.Curso.Add(new Curso()
                {
                    Nombre = "Calculo multivariado",
                    Facultad = matematicas

                });
                db.SaveChanges();
            }
        }

        private void CrearAlumnosCursoYFacultad()
        {
            using (var db = new EntityTestEntities())
            {
                Facultad facultad = new Facultad()
                {
                    Nombre = "Economia"
                };
                var curso = new Curso()
                {
                    Facultad = facultad,
                    Nombre = "Econometria",
                    Alumno = new List<Alumno>()
                    {
                        new Alumno() { Nombre = "Carlos Alvarez",FechaDeNacimiento = DateTime.Now.AddYears(-29) },
                        new Alumno() { Nombre = "Agusto Ferrando", FechaDeNacimiento = DateTime.Now.AddYears(-39) }
                    }
                };
                db.Curso.Add(curso);

                db.SaveChanges();
            }
        }
    }
}
