using Shop.Domain.Entities;
using Shop.Infrastructure.EFDataContext;
using Shop.Services.Interfaces.Handlers;
using Shop.Services.Interfaces.Requests;
using Shop.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.implementation
{
    public class EFShedulerTaskHandler : ISheduleTaskHandler
    {
        public IEnumerable<RegisteredShedulerTask> GetAllSheduler()
        {
            using (var db = new ShopDb())
            {
                return db.SheduleTasks
                         .ToList()
                         .Select(x => new RegisteredShedulerTask
                         {
                             Id = x.Id,
                             Description = x.Description,
                             Complete = x.Complete,
                             SheduledFor = x.SheduledFor,
                         });
            }
        }


        public RegisteredShedulerTask RegisterSheduler(CreateShedulerTask newSheduler)
        {
            var sheduleTask = new SheduleTask()
            {
                Description = newSheduler.Description,
                Complete = newSheduler.Complete,
                SheduledFor = newSheduler.SheduledFor
            };
            using (var db = new ShopDb())
            {
                db.SheduleTasks.Add(sheduleTask);
                db.SaveChanges();
                return new RegisteredShedulerTask()
                {
                    Id = sheduleTask.Id,
                    Description = sheduleTask.Description,
                    Complete = sheduleTask.Complete,
                    SheduledFor = sheduleTask.SheduledFor

                };
            }
        }
    }
}
