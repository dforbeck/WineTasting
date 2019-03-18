using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WineTasting.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tastings, Wines, Ratings, oh my...";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please contact us any time!";

            return View();
        }


    }
}