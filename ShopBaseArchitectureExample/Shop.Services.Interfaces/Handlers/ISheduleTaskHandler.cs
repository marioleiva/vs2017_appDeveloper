using Shop.Services.Interfaces.Requests;
using Shop.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Interfaces.Handlers
{
    public interface ISheduleTaskHandler
    {
        RegisteredShedulerTask RegisterSheduler(CreateShedulerTask newSheduler);
        IEnumerable<RegisteredShedulerTask> GetAllSheduler();
    }
}
