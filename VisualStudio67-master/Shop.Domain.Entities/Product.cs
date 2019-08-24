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
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
