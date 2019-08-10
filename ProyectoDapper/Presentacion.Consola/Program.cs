using PersistenciaDatosEF;
using PersistenciaDeDatos.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ChinookEntities();

            db.Database.Log = sql =>
            {
                Console.WriteLine(sql);
            };

            //  bien 
            var resultado = db.InvoiceLines
                .Include("Track")
                .Select(x => new
                {
                    InvoiceLineId = x.InvoiceLineId,
                    NombreDelTrack = x.Track.Name
                })
                .ToList();
            resultado.ForEach(x =>
            {
                Console.WriteLine($" {x.InvoiceLineId} ) {x.NombreDelTrack}");
            });

            //mal
            //var resultado = db.InvoiceLines
            //    .Select(x => new
            //    {
            //        InvoiceLineId = x.InvoiceLineId,
            //        NombreDelTrack = x.Track.Name
            //    })
            //    .ToList();
            //resultado.ForEach(x =>
            //{
            //    Console.WriteLine($" {x.InvoiceLineId} ) {x.NombreDelTrack}");
            //});


            //db.Database.Log = sql =>
            //{
            //    Console.WriteLine(sql);
            //};

            //var invoice = new Invoice()
            //{
            //    BillingAddress = "av",
            //    BillingCity = "lima",
            //    BillingCountry = "peru",
            //    BillingPostalCode = "3",
            //    BillingState = "lima",
            //    CustomerId = 1,
            //    InvoiceDate = DateTime.Now,
            //    Total = 400,

            //    InvoiceLines = new List<InvoiceLine>()
            //    {
            //        new InvoiceLine()
            //        {
            //            Quantity = 2,
            //            TrackId = 2,
            //            //Track = "primero",
            //            UnitPrice = 200
            //        },
            //        new InvoiceLine()
            //        {
            //            Quantity = 2,
            //            TrackId = 2,
            //           // Track = "segundo",
            //            UnitPrice = 200
            //        }
            //    }
            //};
            //db.Invoices.Add(invoice);
            //db.SaveChanges();


            //db.ListarCustomers().ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x)
            //};

            Console.ReadKey();
        }

        private static void EjecutarCOdigoDApper()
        {
            // ejecutar sql en el codigo
            GestorDeCustomers gestorDeCustomers = new GestorDeCustomers();
            gestorDeCustomers.ListarCustomer().ForEach(x =>
            {
                Console.WriteLine($" Lista dirección { x.Address} Lista ciudades {x.City } ");
            });

            gestorDeCustomers.ListarCustomer()
                .Select(x => x.City)
                .Distinct()
                .ToList()
                .ForEach(x => gestorDeCustomers.InsertarGenre(x));

        }

        private static void MisPrimeros()
        {
            var db = new ChinookEntities();

            //db.Artists.Select(x => x.Name).ToList().ForEach(x => Console.WriteLine(x));

            db.Artists
                .Where(x => x.ArtistId > 10)
                .Select(x => x.Name)
                .Where(x => x.Contains("ty"))
                .ToList().ForEach(x => Console.WriteLine(x));


            var art = db.Artists.Find(280);
            art.Name = "Party Editado";
            db.SaveChanges();

            var artista = new Artist()
            {
                Name = "party mario"
            };
            db.Artists.Add(artista);
            db.SaveChanges();


            var artis = db.Artists.Where(x => x.ArtistId > 200).ToList();
            int i = 1;
            artis.ForEach(x =>
            {
                x.Name = "PArty" + i++;
            });
            db.SaveChanges();

            var filtrarDNI = true;
            var ique = db.Artists.Select(x => x);
            if (filtrarDNI)
            {
                ique = ique.Where(x => x.Name.Contains("party"));
            }
            ique.Select(x => x.Name).ToList().ForEach(a => Console.WriteLine(a));

            //var nombre = db.Artists.Select(x => x.Name);
            // Console.WriteLine();
        }
    }
}
