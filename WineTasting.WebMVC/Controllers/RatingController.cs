using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineTasting.Models.Rating;

namespace WineTasting.WebMVC.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            var model = new RatingListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}