﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Interfaces.Request
{
    public class CreatePoducto
    {
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int CategoryId { get; set; }
    }
}
