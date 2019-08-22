using Shop.Domain.Entities;
using Shop.Infrastructure.EFDataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ShopDb())
            {
                var product = new Product()
                {
                    Id = 3,
                    Descripcion = "Es una Fruta",
                    Name = "Sandia",
                    CategoryId = 1
                };
                db.Entry(product).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
