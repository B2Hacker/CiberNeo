using CiberNeo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiberNeo.Controllers
{
    [CustomAuthorize(Users="1,2")]
    public class CategoriasController : Controller
    {
        DBConnection db = new DBConnection();

        static List<Categoria> Categorias = new List<Categoria>();
        public CategoriasController()
        {
            Categorias = db.GetCategorias();
        }

        // GET: Categorias
        public ActionResult Index()
        {
            return View(Categorias);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Categoria categoria = Categorias.FirstOrDefault(x => x.IdCategoria == id);
                if (categoria != null)
                    return View(categoria);
            }
            return RedirectToAction("Index");
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    //Guardar a la base de datos
                    db.SetCategoria(categoria, 1);

                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Categoria categoria = Categorias.FirstOrDefault(x => x.IdCategoria == id);
                if (categoria != null)
                    return View(categoria);
            }
            return RedirectToAction("Index");
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    //Actualizar a la base de datos

                    db.SetCategoria(categoria, 2);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Categoria categoria = Categorias.FirstOrDefault(x => x.IdCategoria == id);
                if (categoria != null)
                    return View(categoria);
            }
            return RedirectToAction("Index");
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoria.IdCategoria = (int)id;
                    db.SetCategoria(categoria, 3);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(categoria);
        }
        }
    }

