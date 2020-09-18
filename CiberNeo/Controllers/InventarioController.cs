using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiberNeo.Models;

namespace CiberNeo.Controllers
{
    [CustomAuthorize(Users = "1,2")]
    public class InventarioController : Controller
    {
        DBConnection db = new DBConnection();
        static List<Producto> ListaProductos = new List<Producto>();
        static List<Proveedor> ListaProveedor = new List<Proveedor>();
        static List<Inventario> ListaInventario = new List<Inventario>();
        public List<SalidaInventario> Salidas = new List<SalidaInventario>();


        public InventarioController()
        {
            ListaProductos = db.GetProductos();
            ListaProveedor = db.GetProveedores();
            ListaInventario = db.GetInventarios();
            Salidas = db.GetSalidas();
        }

        // GET: Inventario
        public ActionResult Index()
        {
            foreach (Inventario inv in ListaInventario)
            {
                // Recorre cada registro de inventario y recuperael producto y proveedor de cada uno
                inv.producto = ListaProductos.FirstOrDefault(x => x.IdProducto == inv.IdProducto);
                inv.proveedor = ListaProveedor.FirstOrDefault(x => x.IdProveedor == inv.IdProveedor);
            }
            // Una vez que complete la lista de inventario, la envia a la vista de Index
            return View(ListaInventario);
        }

        public ActionResult Create()
        {
            //Estas Listas son para llenar los elementos DropDownList en la vista Create
            ViewBag.Productos = ListaProductos;
            ViewBag.Proveedores = ListaProveedor;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Inventario inventario)
        {
            if (ModelState.IsValid)                  // Verifica que los datos sean correctos
            {
                db.SetInventarios(inventario, Operacion.Insertar);

                return RedirectToAction("Index");    //Redirige al Index de Inventario
            }
            ViewBag.Productos = ListaProductos;
            ViewBag.Proveedores = ListaProveedor;
            return View(inventario);                 //Si el modelo es invalido regresa al Create
        }

        public ActionResult Salida()
        {   // Envia la lista de productos a la vista de Salida
            ViewBag.Productos = ListaProductos;
            //Muestra la vista de Salida
            return View();
        }

        [HttpPost]
        public ActionResult Salida(int[] producto, int[] cantidad)
        {
            // El arreglo de producto contiene los productos para realizar la salida de inventario
            if (producto.Length > 0)
            {
                SalidaInventario salida = new SalidaInventario();
                int cont = 0;
                foreach (int p in producto)
                {
                    salida = new SalidaInventario();
                    // Calcula el nuevo IdSalida del registro
                    salida.IdSalida = 1;
                    if (Salidas.Count > 0)
                        salida.IdSalida = Salidas.Max(x => x.IdSalida) + 1;
                    // Establecemos las demas propiedades del modelo
                    salida.IdProducto = p;
                    salida.Cantidad = cantidad[cont];
                    salida.producto = ListaProductos.FirstOrDefault(x => x.IdProducto == p);
                    salida.Monto = salida.Cantidad * salida.producto.Precio * 1.08;
                    salida.FechaRegistro = DateTime.Now;
                    salida.IdUsuario = 0; // Este valor se debe de tomar de la variable de Session["Usuario"]
                    Salidas.Add(salida);    // Agregamos el producto a la lista de salidas
                    cont++;             // Incrementa contador
                    salida = null;      // Limpia el modelo para el siguiente ciclo
                }
               // db.Guardar(Salidas);
                // Esta vista muestra los registros del modelo SalidaInventario con una plantilla de tipo List
                return RedirectToAction("Reporte");
            }
            return View();
        }

        public ActionResult Reporte()
        {
            return View(Salidas);
        }
    }
}