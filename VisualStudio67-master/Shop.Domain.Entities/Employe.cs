using Shop.Domain.Entities.Shared;
using Shop.Domain.Entities.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Employe : TBaseEntity
    {
        public string Nombre { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public Sex Sex { get; set; }
        public HashSet<SalesTurn> SaleTurns { get; set; }
    }
}
