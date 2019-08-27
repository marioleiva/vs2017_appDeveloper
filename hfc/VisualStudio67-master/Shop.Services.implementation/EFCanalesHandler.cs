using Shop.Infrastructure.EFDataContext;
using Shop.Services.Interfaces.Handlers;
using Shop.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.implementation
{
    public class EFCanalesHandler : ICanalesHandler
    {
        public IEnumerable<RegisteredCanales> GetAllCanales()
        {
            using (var db = new ShopDb())
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
