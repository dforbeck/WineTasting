using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WineTasting.WebMVC.Controllers
{
    public class WineController : Controller
    {
        // GET: Wine
        public ActionResult Index()
        {
            return View();
        }
    }
}