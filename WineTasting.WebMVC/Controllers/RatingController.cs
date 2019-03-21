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
        public ActionResult Index(int wineId)
        {
            var wineSvc = CreateWineService();
            var wine = wineSvc.GetWineById(wineId);

            var ratingService = CreateRatingService();
            var ratings = ratingService.GetRatingsbyWineId(wine);

            return View(ratings);
        }

        public ActionResult Create(int wineId)
        {
            var wineSvc = CreateWineService();
            var wine = wineSvc.GetWineById(wineId);

            var ratingSvc = CreateRatingService();
           
            var model = new RatingCreate
            {
                WineId = wineId,
                CodeForBlindTasting = wine.CodeForBlindTasting
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingCreate model, int wineId)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRatingService();

            if (service.CreateRating(model)) 
                {
                TempData["SaveResult"] = "Your Rating was created.";
                return RedirectToAction("Index", "Rating", new { wineId});
                };

            ModelState.AddModelError("", "Rating could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRatingService();
            var detail = service.GetRatingById(id);
            var model = new RatingEdit
            {
                OwnerId = detail.OwnerId,
                RatingId = detail.RatingId,
                WineId = detail.WineId,
                CodeForBlindTasting = detail.CodeForBlindTasting,
                GuestRating = detail.GuestRating,
                Comments = detail.Comments
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.RatingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRatingService();

            if (service.UpdateRating(model))
            {
                TempData["SaveResult"] = "Your Rating was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Rating could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRatingService();

            service.DeleteRating(id);

            TempData["SaveResult"] = "Your Rating was deleted";

            return RedirectToAction("Index");
        }

        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }

        private WineService CreateWineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WineService(userId);
            return service;
        }               
    }
}