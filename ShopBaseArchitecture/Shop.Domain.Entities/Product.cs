using Shop.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Product : TBaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // fluent api entity framework varchar size
        // modelBuilder.Entity<MyEntity>().Property(e => e.Comment).HasColumnType("VARCHAR").HasMaxLength(250);
    }
}
