using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiberNeo.Areas.Inicio.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Inicio/Inicio
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Catalogo()
        {
            return View();
        }

        public ActionResult Ubicacion()
        {
            return View();
        }
    }
}
