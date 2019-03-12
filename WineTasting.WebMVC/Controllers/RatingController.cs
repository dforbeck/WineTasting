using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineTasting.Models.Rating;
using WineTasting.Services;

namespace WineTasting.WebMVC.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            var model = service.GetRatings();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRatingService();

            if (service.CreateRating(model)) 
                {
                TempData["SaveResult"] = "Your Rating was created.";
                return RedirectToAction("Index");
                };

            ModelState.AddModelError("", "Rating could not be created.");

            return View(model);
        }

        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }
    }
}