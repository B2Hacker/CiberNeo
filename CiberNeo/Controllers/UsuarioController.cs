using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiberNeo.Models;

namespace CiberNeo.Controllers
{
    [CustomAuthorize(Users = "1,2")]
    public class UsuariosController : Controller
    {

        //DBContext db = new DBContext();
        DBConnection db = new DBConnection();

        static List<Usuario> ListaUsuarios = new List<Usuario>();

        public UsuariosController()
        {
            ListaUsuarios = db.GetUsuarios();
        }

        public ActionResult Index()
        { //regresa la vista y la envia como parametro la lista de usuarios
            return View(ListaUsuarios);
        }

        //Muestra el formulario de create
        public ActionResult Create()
        {
            return View();
        }

        //Controla el submit del boton guardar de Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        { //Verifica si los datos son correctos en base al modelo
            if (ModelState.IsValid)
            {
                db.SetUsuario(usuario, 1);

                //Volvemos al inicio
                return RedirectToAction("Index");

            }
            //Si no cumple con la validacion regresamos a la vista de create
            return View(usuario);
        }

        //Muestra el formulario de Edit
        public ActionResult Edit(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el usuario en la lista en base al id
                Usuario usuario = ListaUsuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (usuario != null)
                    return View(usuario);        //Si se encuentra el usuario en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el usuario es nulo o el id es nulo
        }

        //Controla el submit del boton guardar de Edit
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        { //Verifica si los datos son correctos en base al modelo
            if (ModelState.IsValid)
            {

                db.SetUsuario(usuario, 2);

                //Volvemos al inicio
                return RedirectToAction("Index");


            }
            //Si no cumple con la validacion regresamos a la vista de Edit
            return View(usuario);
        }
        //Muestra el formulario de Delete
        public ActionResult Delete(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el usuario en la lista en base al id
                Usuario usuario = ListaUsuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (usuario != null)
                    return View(usuario);        //Si se encuentra el usuario en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el usuario es nulo o el id es nulo
        }

        //Controla el submit del boton guardar de Edit
        [HttpPost]
        public ActionResult Delete(int? Id, Usuario usuario)
        { 
            usuario.IdUsuario = (int)Id;
            db.SetUsuario(usuario,3);
            return RedirectToAction("Index");
        }

        //Muestra el formulario de Delete
        public ActionResult Details(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el usuario en la lista en base al id
                Usuario usuario = ListaUsuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (usuario != null)
                    return View(usuario);        //Si se encuentra el usuario en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el usuario es nulo o el id es nulo
        }
    }
}
