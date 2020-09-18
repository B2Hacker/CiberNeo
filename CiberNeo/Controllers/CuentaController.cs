using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiberNeo.Models;

namespace CiberNeo.Controllers
{
    public class CuentaController : Controller
    {

        DBConnection db = new DBConnection();

        static List<Usuario> ListaUsuarios = new List<Usuario>();

        public CuentaController()
        {
            ListaUsuarios = db.GetUsuarios();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cliente()
        {
            return View();
        }
    }
}