using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiberNeo.Models;

namespace CiberNeo.Controllers
{
    [CustomAuthorize(Users = "1,2")]
    public class ProveedorController : Controller
    {
        DBConnection db = new DBConnection();
        static List<Proveedor> ListaProveedor = new List<Proveedor>();

        public ProveedorController()
        {
            ListaProveedor = db.GetProveedores();
        }

        public ActionResult Index()
        { //regresa la vista y la envia como parametro la lista de Proveedor
            return View(ListaProveedor);
        }

        //Muestra el formulario de create
        public ActionResult Create()
        {
            return View();
        }

        //Controla el submit del boton guardar de Create
        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        { //Verifica si los datos son correctos en base al modelo
            if (ModelState.IsValid)
            {

                db.SetProveedores (proveedor, 1 );

                //Volvemos al inicio
                return RedirectToAction("Index");

            }
            //Si no cumple con la validacion regresamos a la vista de create
            return View(proveedor);
        }

        //Muestra el formulario de Edit
        public ActionResult Edit(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el Proveedor en la lista en base al id
                Proveedor proveedor = ListaProveedor.FirstOrDefault(x => x.IdProveedor == id);
                if (proveedor != null)
                    return View(proveedor);        //Si se encuentra el Proveedor en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el Proveedor es nulo o el id es nulo
        }

        //Controla el submit del boton guardar de Edit
        [HttpPost]
        public ActionResult Edit(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            { 
            db.SetProveedores(proveedor, 2);
            return RedirectToAction("Index");

            }
            return View(proveedor);
        }


        public ActionResult Delete(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el Proveedor en la lista en base al id
                Proveedor proveedor = ListaProveedor.FirstOrDefault(x => x.IdProveedor == id);
                if (proveedor != null)
                    return View(proveedor);        //Si se encuentra el Proveedor en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el Proveedor es nulo o el id es nulo
        }


        //Controla el submit del boton guardar de Edit
        [HttpPost]
        public ActionResult Delete(int? id, Proveedor proveedor)
        {
            proveedor.IdProveedor = (int)id;
            db.SetProveedores(proveedor, 3);
            return RedirectToAction("Index");
        }

        //Muestra el formulario de Delete
        public ActionResult Details(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el Proveedor en la lista en base al id
                Proveedor proveedor = ListaProveedor.FirstOrDefault(x => x.IdProveedor == id);
                if (proveedor != null)
                    return View(proveedor);        //Si se encuentra el Proveedor en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el Proveedor es nulo o el id es nulo
        }
    }
}