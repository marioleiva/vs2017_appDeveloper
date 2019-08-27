using App.Postpago.EFDataContext;
using App.Postpago.Interfaces.Handler;
using App.Postpago.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Postpago.Implementation
{
    public class EFCanalesHandler : ICanalesHandler
    {
        public IEnumerable<RegisteredCanales> GetAllCanales()
        {
            using (var db = new AppDb())
            {
                return db.Canales.ToList().Select(x => new RegisteredCanales
                {
                    Plan = x.Plan,
                    HD = x.HD,
                    SD = x.SD,
                    Audio = x.Audio
                });
            }
        }
    }
}
