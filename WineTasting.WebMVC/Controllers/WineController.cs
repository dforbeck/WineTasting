using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineTasting.Models.Wine;

namespace WineTasting.WebMVC.Controllers
{
    [Authorize]
    public class WineController : Controller
    {
        // GET: Wine
        public ActionResult Index()
        {
            var model = new WineListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}