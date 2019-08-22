using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.EFDataContext
{
    public class ShopDb : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SalesTurn> SalesTurns { get; set; }
        public DbSet<Employe> Employees { get; set; }

        public ShopDb() : base("ShopDb")
        {

        }

    }
}
