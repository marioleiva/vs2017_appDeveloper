using App.Postpago.Implementation;
using App.Postpago.Interfaces.Handler;
using App.Postpago.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.Postpago.WebPage.Controllers
{
    public class CanalesManagementController : ApiController
    {
        ICanalesHandler _canalesHandler = new EFCanalesHandler();

        [HttpGet]
        public IEnumerable<RegisteredCanales> GetAllCanales()
        {
            return this._canalesHandler.GetAllCanales();
        }
    }
}
