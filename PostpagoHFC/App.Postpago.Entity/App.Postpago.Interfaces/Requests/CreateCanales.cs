using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Postpago.Interfaces.Requests
{
    public class CreateCanales
    {
        public string Plan { get; set; }
        public int HD { get; set; }
        public int SD { get; set; }
        public int Audio { get; set; }
    }
}
