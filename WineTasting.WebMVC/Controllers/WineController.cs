using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineTasting.Data;
using WineTasting.Models.Wine;
using WineTasting.Services;

namespace WineTasting.WebMVC.Controllers
{
    [Authorize]
    public class WineController : Controller
    {
        // GET: Wine
        public ActionResult Index(int tastingId)
        {
            var tastingSvc = CreateTastingService();
            var tasting = tastingSvc.GetTastingById(tastingId);

            var wineSvc = CreateWineService();
            var wines = wineSvc.GetWinesByTastingId(tasting);

            return View(wines);
        }

        public ActionResult Create(int tastingId)
        {
            var tastingSvc = CreateTastingService();
            var tasting = tastingSvc.GetTastingById(tastingId);

            var wineSvc = CreateWineService();
            
            var model = new WineCreate 
            {
                TastingId = tastingId,
                TastingDate = tasting.TastingDate
            };

            /*   ViewBag.TastingId = new SelectList(tastingSvc.GetWinesByTastingId(tastingId), "TastingId", "TastingDate"); */
        
            return View(model);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WineCreate model, int tastingId)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWineService();

            if (service.CreateWine(model))
            {
                TempData["SaveResult"] = "Your Wine was created.";
                return RedirectToAction("Index","Wine", new { tastingId });
            };

            ModelState.AddModelError("", "Wine could not be created.");

            return View(model);          
        }

        public ActionResult Details (int id)
        {
            var svc = CreateWineService();
            var model = svc.GetWineById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateWineService();
            var detail = service.GetWineById(id);
            var model = new WineEdit
            {
                OwnerId = detail.OwnerId,
                WineId = detail.WineId,
                TastingId = detail.TastingId,
                Brand = detail.Brand,
                SubBrand = detail.SubBrand,
                WineVarietal = detail.WineVarietal,
                Region = detail.Region,
                Year = detail.Year,
                CodeForBlindTasting = detail.CodeForBlindTasting
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WineEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if(model.WineId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWineService();

            if (service.UpdateWine(model))
            {
                TempData["SaveResult"] = "Your Wine was updated.";
                    return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Wine could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWineService();
            var model = svc.GetWineById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWineService();

            service.DeleteWine(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private WineService CreateWineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new WineService(userId);
            return service;
        }

        private TastingService CreateTastingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new TastingService(userId);
            return service;
        }
    }
}