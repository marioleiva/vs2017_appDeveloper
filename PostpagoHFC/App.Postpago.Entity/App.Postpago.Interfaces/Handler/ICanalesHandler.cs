using App.Postpago.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Postpago.Interfaces.Handler
{
    public interface ICanalesHandler
    {
        IEnumerable<RegisteredCanales> GetAllCanales();
    }
}
