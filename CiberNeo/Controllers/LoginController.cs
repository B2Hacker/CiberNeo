using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiberNeo.Models;

namespace CiberNeo.Controllers
{
    public class LoginController : Controller
    {
        DBConnection db = new DBConnection();
        static List<Usuario> ListaUsuarios = new List<Usuario>();
        

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            ListaUsuarios = db.GetUsuarios();   //Lee el archivo y recupera los usuarios
            Usuario user = ListaUsuarios.FirstOrDefault(x => x.Username == usuario.Username);


            if (user != null)
            {
                if (usuario.Password == user.Password)
                {
                    if (user.IdPerfil == 1)

                    {
                        Session["Usuario"] = user;
                        return RedirectToAction("Inicio", "Home");
                    }
                    else if (user.IdPerfil == 5)
                    {
                        Session["Usuario"] = user;
                        return RedirectToAction("Inicio", "Principal", new { Area = "Inicio" });
                    }
                    else
                        ViewBag.Mensage = "El usuario no tiene acceso al sistema";
                }
                else
                    ViewBag.Mensage = "La contraseña es incorrecta";
            }
            else
                ViewBag.Mensage = "El usuario no existe en el sistema";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Inicio", "Principal", new { Area = "Inicio"});
        }

        //Metodo para visualizar la vista de Recovery
        public ActionResult Recovery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recovery(string Busqueda)
        {
            try
            {
                ListaUsuarios = db.GetUsuarios();
                Usuario usuario = ListaUsuarios.FirstOrDefault(x => x.Username == Busqueda
                || x.CorreoElectronico == Busqueda);
                if (usuario != null)
                {
                    string mensaje = string.Format("Usuario: {0}, Contraseña: {1}", usuario.Username, usuario.Password);
                    Mail.SendMail(usuario.CorreoElectronico, "Recuperación de cuenta de usuario", mensaje);
                    ViewBag.Mensaje = "Se envió un correo electrónico con los datos de acceso al sistema";
                }
                else
                    ViewBag.Mensaje = "No se encontraron datos que coincidan con la información proporcionada.";
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Intente nuevamente. ";
            }
            return View();
        }
    }
}