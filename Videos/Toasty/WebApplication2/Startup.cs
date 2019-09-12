using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApplication2.Startup))]

namespace WebApplication2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                var hubConfiguration = new HubConfiguration();
                hubConfiguration.EnableDetailedErrors = true;
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
