using Shop.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Category : TBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public HashSet<Product> Products { get; set; }
    }
}
