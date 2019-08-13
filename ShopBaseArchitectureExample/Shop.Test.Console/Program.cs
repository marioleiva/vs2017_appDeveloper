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
                db.Products.Add(new Product()
                {
                    Descripcion = "Mi primer producto registrado",
                    Name = "Chocolate",
                    Category = new Category()
                    {
                        Name = "Golosina",
                        Description = "Productos azucarados para niños"
                    }
                });
                db.SaveChanges();
            }
        }
    }
}
