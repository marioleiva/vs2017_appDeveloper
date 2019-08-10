using PersistenciaDeDatos.Gestores;
using PersistenciaDeDatos.Modelos;
using PersistenciaDeDatosConEF;
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
                Console.WriteLine("========");
            };

            var resultado = db.InvoiceLines
                              .ToList()
                              .Select(x => new
                              {
                                  InvoiceLineId = x.InvoiceLineId,
                                  NombreDelTrack = x.Track.Name
                              });

            resultado.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.InvoiceLineId} ) {x.NombreDelTrack}");

            });
                            
            Console.ReadKey();
        }

        private static void EjecutarCodigoDeDapper()
        {
            var gestorDePlayList = new GestorDePlayList();

            var listaDeplayList = new List<PersistenciaDeDatos.Modelos.Playlist>()
            {
                gestorDePlayList.RecuperarPlayListPorId(1),
                gestorDePlayList.RecuperarPlayListPorId(2),
                gestorDePlayList.RecuperarPlayListPorId(3),
                gestorDePlayList.RecuperarPlayListPorId(4),
                gestorDePlayList.RecuperarPlayListPorId(5)
            };

            listaDeplayList.ForEach(x =>
            {
                Console.WriteLine($"{x.Name} Tiene {x.Tracks.Count} Tracks");
            });


            var gestorDeCustomers = new GestorDeCustomers();

            gestorDeCustomers.RecuperarCustomersPorId(
                new List<int>()
                {
                    1,
                    2,
                    3,
                    4
                }
            ).ForEach(x => Console.WriteLine($"{x.CustomerId}) {x.FirstName} "));

        }

        private static void MisPrimerosPasosConEF()
        {
            var db = new ChinookEntities();
            //var artista = new Artist()
            //{
            //    Name = "Party in The house"
            //};

            //db.Artists.Add(artista);
            //db.SaveChanges();

            //var artista = db.Artists.First(x=>x.Name.Contains("EDITADA"));
            //artista.Name="Party EDITADA EDITADA";
            //db.SaveChanges();

            var artistas = db.Artists.Where(x => x.ArtistId > 200).ToList();
            int i = 1;
            artistas.ForEach(x =>
            {
                x.Name = "Party " + i++;
            });
            db.SaveChanges();

            db.Artists
                .Select(x => x.Name)
                .Where(x => x.Contains("Party"))
                .ToList()
                .ForEach(x => Console.WriteLine(x));


            db.Database.Log = sql =>
            {
                Console.WriteLine(sql);
                Console.WriteLine("");
                Console.WriteLine("  ==========================   ");
                Console.WriteLine("");
            };

            var invoice = new Invoice()
            {
                BillingAddress = "Av La Marina 766",
                BillingCity = "La Perla",
                BillingCountry = "Peru",
                BillingPostalCode = "Callao 04",
                BillingState = "Callao",
                CustomerId = 1,
                InvoiceDate = DateTime.Now,
                Total = 300,
                InvoiceLines = new List<InvoiceLine>()
                {
                    new InvoiceLine()
                    {
                        Quantity = 2,
                        TrackId = 2,
                        UnitPrice = 100
                    },
                    new InvoiceLine()
                    {
                        Quantity = 2,
                        TrackId = 2,
                        UnitPrice = 200
                    }
                }
            };

            db.Invoices.Add(invoice);
            db.SaveChanges();

            db.ListarCustomers().ToList().ForEach(x =>
            {
                Console.WriteLine(x.Address);
            });
        }
    }
}
