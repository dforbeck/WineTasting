using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineTasting.Models.Tasting;
using WineTasting.Services;

namespace WineTasting.WebMVC.Controllers
{
    [Authorize]
    public class TastingController : Controller
    {
        // GET: Tasting
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TastingService(userId);
            var model = service.GetTastings();

            return View(model);
        }

        //Create the Tasting
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TastingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTastingService();

            if (service.CreateTasting(model))
            {
                TempData["SaveResult"] = "Your Tasting was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Tasting could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTastingService();
            var model = svc.GetTastingById(id);

            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var service = CreateTastingService();
            var detail = service.GetTastingById(id);
            var model = new TastingEdit
            {
                OwnerId = detail.OwnerId,
                TastingId = detail.TastingId,
                TastingDate = detail.TastingDate,
                Title = detail.Title,
                Host = detail.Host

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TastingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.TastingId != id)
            {
                ModelState.AddModelError("", "Id Mistmatch");
                return View(model);
            }

            var service = CreateTastingService();

            if (service.UpdateTasting(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTastingService();
            var model = svc.GetTastingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTastingService();

            service.DeleteTasting(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private TastingService CreateTastingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TastingService(userId);
            return service;
        }
    }
}