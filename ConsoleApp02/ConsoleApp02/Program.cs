using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp02
{
    class Program
    {
        static void Main(string[] args)
        {
            //var db = new ChinookEntities();

            using (ChinookEntities db = new ChinookEntities())
            {
                
                db.Database.Log = sql => Console.WriteLine(sql);

                var albums = db.Album.ToList();
                var artists = db.Artist //.Take(2)
                    .ToList();

                albums.ForEach(x =>
                {
                    x.Artist = artists.FirstOrDefault(y => y.ArtistId.Equals(x.ArtistId));
                });

                albums.ForEach(x =>
                {
                    Console.WriteLine($" {x.Title} - {x.Artist.Name} ");
                });

                // lazy loading
                //db.Artist.ToList().ForEach(artista =>
                //{
                //    artista.Album.ToList().ForEach(album =>
                //    {
                //        Console.WriteLine($"{artista.Name}");
                //    });
                //});
            }
            Console.ReadKey();
        }

        static void EagerLoading ()
        {
            using (ChinookEntities db = new ChinookEntities())
            {

                // eager loading
                db.Artist.Include("Album")
                .Take(2)
                .ToList()
                .ForEach(artista =>
                {
                    artista.Album.ToList().ForEach(album =>
                    {
                        Console.WriteLine($"{artista.Name} - {album.Title}");
                    });
                });
            }
        }
    }
}
