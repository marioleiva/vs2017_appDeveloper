using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Quartz;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(windowsService =>
            {
                windowsService.ScheduleQuartzJobAsService(service => {
                    service.WithJob(() => JobBuilder.Create<Sincronizar>().Build())
                           .AddTrigger(() => TriggerBuilder.Create()
                                            .WithSimpleSchedule(action =>
                                                action.WithIntervalInSeconds(5).RepeatForever())
                                            .Build());
                });
            });
        }

    }

    public class Sincronizar : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("algo");
        }
    }
}
