using Entidades;
using Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EventoDb())
            {
                var evento = new Evento()
                {
                    Fecha = DateTime.Now,
                    Descripcion = "segundo",
                    Estado = true,
                    FechaMaximaInscripcion = DateTime.Now
                };
                db.Entry(evento).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
            using (var db = new EventoDb())
            {
                var evento = new Evento()
                {
                    Id = 3,
                    Fecha = DateTime.Now,
                    Descripcion = "tercero modificado",
                    Estado = true,
                    FechaMaximaInscripcion = DateTime.Now
                };
                db.Entry(evento).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            using (var db = new EventoDb())
            {
               // var evento = new Evento();
              var eventos =  db.Eventos.ToList();
               
                eventos.ToList().ForEach(x=> 
                {
                    Console.WriteLine($" {x.Id}-{x.Descripcion}  " );
                });
            }
            Console.ReadKey();


        }
    }
}
