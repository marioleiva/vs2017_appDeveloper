using Shop.Domain.Entities;
using Shop.Infrastructure.EFDataContext;
using System;
using System.Collections.Generic;
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
                //db.Products.Add(new Product()
                //{
                //    Descripcion = "Mi primer producto registrado",
                //    Name = "Chocolate",
                //    Category = new Category()
                //    {
                //        Name = "Golosina",
                //        Description = "Productos azucarados para niños"
                //    }
                //});

                var product = new Product()
                {
                    Descripcion = "Es una fruta",
                    Name = "Sandia",
                    CategoryId = 1
                };
                db.Entry(product).State = System.Data.Entity.EntityState.Added; 
                db.SaveChanges();
            }
        }
    }
}
