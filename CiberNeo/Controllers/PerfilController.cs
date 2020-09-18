using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiberNeo.Models;

namespace CiberNeo.Controllers
{
    [CustomAuthorize(Users = "1,2")]
    public class PerfilController : Controller
    {

        DBConnection db = new DBConnection();

        static List<Perfil> Perfiles = new List<Perfil>();

        public PerfilController()
        {
            Perfiles = db.GetPerfiles();
        }

        public ActionResult Index()
        { //regresa la vista y la envia como parametro la lista de Perfil
            return View(Perfiles);
        }

        //Muestra el formulario de create
        public ActionResult Create()
        {
            return View();
        }

        //Controla el submit del boton guardar de Create
        [HttpPost]
        public ActionResult Create(Perfil perfil)
        { //Verifica si los datos son correctos en base al modelo
            if (ModelState.IsValid)
            {
                db.SetPerfiles(perfil, 1);

                //Volvemos al inicio
                return RedirectToAction("Index");



            }
            //Si no cumple con la validacion regresamos a la vista de create
            return View(Perfiles);
        }

        //Muestra el formulario de Edit
        public ActionResult Edit(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el Perfil en la lista en base al id
                Perfil Perfil = Perfiles.FirstOrDefault(x => x.IdPerfil == id);
                if (Perfil != null)
                    return View(Perfil);        //Si se encuentra el Perfil en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el Perfil es nulo o el id es nulo
        }

        //Controla el submit del boton guardar de Edit
        [HttpPost]
        public ActionResult Edit(Perfil perfil)
        { //Verifica si los datos son correctos en base al modelo
            if (ModelState.IsValid)
            {
                db.SetPerfiles(perfil, 2);

                //Volvemos al inicio
                return RedirectToAction("Index");


            }
            //Si no cumple con la validacion regresamos a la vista de Edit
            return View(Perfiles);
        }
        //Muestra el formulario de Delete
        public ActionResult Delete(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el Perfil en la lista en base al id
                Perfil Perfil = Perfiles.FirstOrDefault(x => x.IdPerfil == id);
                if (Perfil != null)
                    return View(Perfil);        //Si se encuentra el Perfil en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el Perfil es nulo o el id es nulo
        }

        //Controla el submit del boton guardar de Edit
        [HttpPost]
        public ActionResult Delete(int? id, Perfil perfil)
        {
            perfil.IdPerfil = (int)id;
            db.SetPerfiles(perfil, 3);

            //Volvemos al inicio
            return RedirectToAction("Index");
        }

        //Muestra el formulario de Delete
        public ActionResult Details(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el Perfil en la lista en base al id
                Perfil Perfil = Perfiles.FirstOrDefault(x => x.IdPerfil == id);
                if (Perfil != null)
                    return View(Perfil);        //Si se encuentra el Perfil en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el Perfil es nulo o el id es nulo
        }
    }
}