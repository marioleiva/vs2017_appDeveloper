using Shop.Services.implementation;
using Shop.Services.Interfaces.Handlers;
using Shop.Services.Interfaces.Requests;
using Shop.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Presentation.WebServices.Controllers
{
    public class ShedulerTaskController : ApiController
    {
        ISheduleTaskHandler _sheduleTaskHandler = new EFShedulerTaskHandler();

        [HttpGet]
        public IEnumerable<RegisteredShedulerTask> GetAllShedulerTask()
        {
            return this._sheduleTaskHandler.GetAllSheduler();
        }

        [HttpPost]
        public RegisteredShedulerTask RegisterProduct(CreateShedulerTask newSheduler)
        {
            return this._sheduleTaskHandler.RegisterSheduler(newSheduler);
        }

    }
}
