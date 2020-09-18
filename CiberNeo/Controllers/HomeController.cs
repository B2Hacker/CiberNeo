using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiberNeo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Inicio", "Principal", new { @area = "Inicio" });
        }
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Restringido()
        {
            return View();
        }
    }
}