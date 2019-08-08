using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesBasicasEnittyFramework
{
    class Program
    {
        public static List<Curso> Curso { get; private set; }

        static void Main(string[] args)
        {
            using (var db = new EntityTestEntities())
            {
                //Alumno alumno = new Alumno();
                Alumno alumno = db.Alumno.Find(8);
 
                alumno.Curso.Add(new Curso()
                {
                    Nombre = "curse one",
                    FacultadId = 4
                });
                alumno.Curso.Add(new Curso()
                {
                    Nombre = "curse two",
                    FacultadId = 4
                });
                db.Alumno.Add(alumno);
                db.SaveChanges();

                Console.WriteLine(alumno.Id);
                Console.WriteLine(alumno.Nombre);
                Console.ReadKey();


                //Facultad facultad = new Facultad()
                //{
                //    Nombre = "Economia"
                //};
                //var curso = new Curso()
                //{
                //    Facultad = facultad,
                //    Nombre = "Econometria",
                //    Alumno = new List<Alumno>()
                //    {
                //        new Alumno() { Nombre = "Mario Leiva",FechaDeNacimiento = DateTime.Now.AddYears(-30) },

                //    }
                //};
                //db.Curso.Add(curso);
                //db.SaveChanges();



                //var alumno = new Alumno()
                //{
                //    Nombre = "Mario Leiva",
                //    FechaDeNacimiento = DateTime.Now.AddYears(-30),
                //    Curso = new List<Curso>()
                //        {
                //            new Curso() {  Nombre="primer curso",FacultadId = 4  },
                //            new Curso() {  Nombre="segundo curso",FacultadId = 4  },

                //        }
                //};
                //db.Alumno.Add(alumno);
                //db.SaveChanges();
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


        private void CrearCursoAlumno()
        {
            using (var db = new EntityTestEntities())
            {
                var curso = new Curso()
                {
                    FacultadId = 4,
                    Nombre = "PROGRAMACIÓN ESTRUCTURADA",
                    Alumno = new List<Alumno>()
                    {
                        new Alumno() { Nombre = "Mario Leiva",FechaDeNacimiento = DateTime.Now.AddYears(-30) },

                    }
                };
                db.Curso.Add(curso);
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
    }
}
