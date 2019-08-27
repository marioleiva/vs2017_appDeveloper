using Shop.Services.implementation;
using Shop.Services.Interfaces.Handlers;
using Shop.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Presentation.WebPage.Controllers
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
