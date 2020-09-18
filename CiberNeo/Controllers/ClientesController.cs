using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiberNeo.Models;

namespace CiberNeo.Controllers
{
    [CustomAuthorize(Users = "1,2")]
    public class ClientesController : Controller
    {
        DBConnection db = new DBConnection();

        static List<Cliente> Clientes = new List<Cliente>();

        public ClientesController()
        {
            Clientes = db.GetClientes();
        }

        // GET: Clientes
        public ActionResult Index()
        {
            return View(Clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Cliente cliente = Clientes.FirstOrDefault(x => x.IdCliente == id);
                if (cliente != null)
                    return View(cliente);
            }
            return RedirectToAction("Index");
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    //Guardar a la base de datos

                    db.SetClientes(cliente, 1);
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Cliente cliente = Clientes.FirstOrDefault(x => x.IdCliente == id);
                if (cliente != null)
                    return View(cliente);
            }
            return RedirectToAction("Index");
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    //Editar a la base de datos

                    db.SetClientes(cliente, 2);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Cliente cliente = Clientes.FirstOrDefault(x => x.IdCliente == id);
                if (cliente != null)
                    return View(cliente);
            }
            return RedirectToAction("Index");
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cliente.IdCliente = (int)id;
                    db.SetClientes(cliente, 3);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
            }
            return View(cliente);
        }
    }
}
