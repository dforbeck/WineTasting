using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WineTasting.Models.Tasting;
using WineTasting.Services;

namespace WineTasting.WebApi.Controllers
{
    [Authorize]
    public class TastingController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            TastingService tastingService = CreateTastingService();
            var tastings = tastingService.GetTastings();
            return Ok(tastings);
        }

        public IHttpActionResult Get(int id)
        {
            TastingService tastingService = CreateTastingService();
            var tasting = tastingService.GetTastingById(id);
            return Ok(tasting);
        }

        public IHttpActionResult Post(TastingCreate tasting)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTastingService();

            if (!service.CreateTasting(tasting))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(TastingEdit tasting)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTastingService();

            if (!service.UpdateTasting(tasting))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTastingService();

            if (!service.DeleteTasting(id))
                return InternalServerError();
            return Ok();
        }

        private TastingService CreateTastingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var tastingService = new TastingService(userId);
            return tastingService;
        }
    }
}
