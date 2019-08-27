using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Interfaces.Requests
{
    public class CreateShedulerTask
    {
        public string Description { get; set; }
        public bool Complete { get; set; }
        public DateTime SheduledFor { get; set; }
    }
}
