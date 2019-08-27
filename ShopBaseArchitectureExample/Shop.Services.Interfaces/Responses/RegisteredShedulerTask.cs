using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Interfaces.Responses
{
    public class RegisteredShedulerTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
        public DateTime SheduledFor { get; set; }



    }
}
