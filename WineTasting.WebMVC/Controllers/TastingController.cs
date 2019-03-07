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

        private TastingService CreateTastingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TastingService(userId);
            return service;
        }
    }
}