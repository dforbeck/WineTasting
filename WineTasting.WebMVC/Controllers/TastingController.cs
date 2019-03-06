using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineTasting.Models.Tasting;

namespace WineTasting.WebMVC.Controllers
{
    [Authorize]
    public class TastingController : Controller
    {
        // GET: Tasting
        public ActionResult Index()
        {
            var model = new TastingListItem[0];
            return View();
        }
    }
}