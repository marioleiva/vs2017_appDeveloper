using Shop.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class ClaroCanalesPlus : TBaseEntity
    {
        public string Plan { get; set; }
        public int HD { get; set; }
        public int SD { get; set; }
    }
}
