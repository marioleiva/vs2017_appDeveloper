using Shop.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class SheduleTask : TBaseEntity
    {
        public string Description { get; set; }
        public bool Complete { get; set; }
        public DateTime SheduledFor { get; set; }
    }
}
