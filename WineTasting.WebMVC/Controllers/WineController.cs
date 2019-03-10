using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineTasting.Models.Wine;
using WineTasting.Services;

namespace WineTasting.WebMVC.Controllers
{
    [Authorize]
    public class WineController : Controller
    {
        // GET: Wine
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WineService(userId);
            var model = service.GetWines();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WineCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWineService();

            if (service.CreateWine(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Wine could not be created.");

            return View(model);

            

        }

        private WineService CreateWineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new WineService(userId);
            return service;
        }
    }
}