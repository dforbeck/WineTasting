using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WineTasting.Services;

namespace WineTasting.WebApi.Controllers
{
    [Authorize]
    public class TastingController : ApiController
    {
        public IHttpActionResult Get()
        {
            TastingService tastingService = CreateTastingService();
            var tastings = tastingService.GetTastings();
            return Ok(tastings);
        }

        private TastingService CreateTastingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var tastingService = new TastingService(userId);
            return tastingService;
        }
    }
}
