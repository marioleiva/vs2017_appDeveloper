using Shop.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class SalesTurn : TBaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Active { get; set; } = true;
        public HashSet<Employe> Employees { get; set; }
    }
}
