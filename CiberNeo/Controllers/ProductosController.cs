using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiberNeo.Models;
using System.IO;

namespace CiberNeo.Controllers
{
    [CustomAuthorize(Users = "1,2")]
    public class ProductoController : Controller
    {
        DBConnection db = new DBConnection();

        static List<Archivo> ListaArchivos = new List<Archivo>();
        static List<Producto> ListaProducto = new List<Producto>();
        static List<Cotizaciones> ListaCotizaciones = new List<Cotizaciones>();
        static List<Cliente> ListaClientes = new List<Cliente>();


        // Accion para mostrar la vista de busqueda de productos
        public ActionResult Busqueda()
        {
            // Para que la vista se pueda mostrar se le envia una lista vacia de productos
            return View(new List<Producto>());
        }

        // Accion para realizar la busqueda del producto(s) en la lista de productos JSON
        [HttpPost]
        public ActionResult Busqueda(string Texto)
        {
            List<Producto> productosencontrados = new List<Producto>();
            if (Texto != null)
            {
                try
                {   // La funcion Contains verifica que el texto exista dentro del valor del campo
                    productosencontrados = ListaProducto.Where(x =>
                        x.Nombre.Contains(Texto) ||
                        x.Marca.Contains(Texto) 
                        //x.Categoria.Descripcion.Contains(Texto) ||
                    ).ToList();
                }
                catch (Exception)
                {
                    ViewBag.Mensaje = "La búsqueda no se realizó, intente nuevamente.";
                }
            }
            return View(productosencontrados);
        }

        public ProductoController()
        {
            ListaArchivos = db.GetArchivos();
            ListaProducto = db.GetProductos();
            ListaCotizaciones = db.GetCotizaciones();
            ListaClientes = db.GetClientes();
        }

        public ActionResult Index()
        { //regresa la vista y la envia como parametro la lista de Producto
            return View(ListaProducto);
        }

        //Muestra el formulario de create
        public ActionResult Create()
        {
            return View();
        }

        //Controla el submit del boton guardar de Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        { //Verifica si los datos son correctos en base al modelo
            if (ModelState.IsValid)
            {
                db.SetProductos(producto, 1);

                //Volvemos al inicio
                return RedirectToAction("Index");

            }
            //Si no cumple con la validacion regresamos a la vista de create
            return View(producto);
        }

        //Muestra el formulario de Edit
        public ActionResult Edit(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el Producto en la lista en base al id
                Producto producto = ListaProducto.FirstOrDefault(x => x.IdProducto == id);
                if (producto != null)
                    return View(producto);        //Si se encuentra el Producto en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el Producto es nulo o el id es nulo
        }

        //Controla el submit del boton guardar de Edit
        [HttpPost]
        public ActionResult Edit(Producto producto)
        { //Verifica si los datos son correctos en base al modelo
            if (ModelState.IsValid)
            {
                db.SetProductos(producto, 2);

                //Volvemos al inicio
                return RedirectToAction("Index");
            }
            return View(producto);

        }


        public ActionResult Delete(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el Producto en la lista en base al id
                Producto producto = ListaProducto.FirstOrDefault(x => x.IdProducto == id);
                if (producto != null)
                    return View(producto);        //Si se encuentra el Producto en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el Producto es nulo o el id es nulo
        }

        //Controla el submit del boton guardar de Edit
        [HttpPost]
        public ActionResult Delete(int? id, Producto producto)
        {
            producto.IdProducto = (int)id;
            db.SetProductos (producto, 3);

            //Volvemos al inicio
            return RedirectToAction("Index");
        }

        //Muestra el formulario de Delete
        public ActionResult Details(int? id)
        {    //Si el id es diferente de null
            if (id != null)
            {          //Busca el Producto en la lista en base al id
                Producto producto = ListaProducto.FirstOrDefault(x => x.IdProducto == id);
                if (producto != null)
                    return View(producto);        //Si se encuentra el Producto en la lista regresa la vista de Edit
            }
            return RedirectToAction("Index");    //Si el Producto es nulo o el id es nulo
        }

        public ActionResult Archivos(int? id)
        {
            //Verificamos que el id del producto este presente
            if (id != null)
            {   //Recupera el producto en base al id
                Producto producto = ListaProducto.FirstOrDefault(x => x.IdProducto == id);
                //Recuperamos los archivos relacionados con el producto
                List<Archivo> archivos = ListaArchivos.Where(x => x.IdProducto == id).ToList();
                //Si el archivo existe muestra la vista
                if (producto != null)
                {
                    ViewBag.Archivos = archivos;
                    return View(new Archivo() { Producto = producto, IdProducto = producto.IdProducto });
                }
            }
            //Si el id o el producto no son validos regresa al Index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Archivos(Archivo archivo, HttpPostedFileBase documento)
        {
            if (ModelState.IsValid)
            {
                if (documento != null)
                {
                    string ruta = Server.MapPath("~/Files/Producto") + archivo.IdProducto;
                    if (!Directory.Exists(ruta))
                        Directory.CreateDirectory(ruta);
                    //Guardamos el archivo y el objeto
                    documento.SaveAs(ruta + "\\" + documento.FileName);
                    archivo.IdArchivo = 1;
                    if (ListaArchivos.Count > 0)
                        archivo.IdArchivo = ListaArchivos.Max(x => x.IdArchivo) + 1;
                    archivo.Url = "~Files/Producto" + archivo.IdProducto + "/" + documento.FileName;
                    ListaArchivos.Add(archivo);

                    //db.Guardar(ListaArchivos);
                    //return RedirectToAction("Index");
                }
            }
            List<Archivo> archivos = ListaArchivos.Where(x => x.IdProducto == archivo.IdProducto).ToList();
            archivo.Producto = ListaProducto.FirstOrDefault(x => x.IdProducto == archivo.IdProducto);
            ViewBag.Archivos = archivos;
            return View(archivo);
        }

        [HttpPost]
        public ActionResult EliminarArchivo(int? IdArchivo)
        {
            if (IdArchivo != null)
            {
                try
                {
                    Archivo archivo = ListaArchivos.FirstOrDefault(x => x.IdArchivo == IdArchivo);
                    int indice = ListaArchivos.FindIndex(x => x.IdArchivo == IdArchivo);
                    string ruta = Server.MapPath(archivo.Url);
                    if (System.IO.File.Exists(ruta))
                        System.IO.File.Delete(ruta);
                    int idproducto = archivo.IdProducto;
                    ListaArchivos.RemoveAt(indice);
                   // db.Guardar(ListaArchivos);
                    return RedirectToAction("Archivos", new { id = idproducto });
                }
                catch (Exception)
                {

                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Cotizacion()
        {   // Envia la lista de productos a la vista de Salida
            ViewBag.Productos = ListaProducto;
            ViewBag.Clientes = ListaClientes;
            //Muestra la vista de Salida
            return View();
        }

        [HttpPost]
        public ActionResult Cotizacion(int[] Producto, int[] Cantidad, int[] Cliente)
        {
            // El arreglo de producto contiene los productos para realizar la salida de inventario
            if (Producto.Length > 0)
            {
                Cotizaciones cotizacion = new Cotizaciones();
                int cont = 0;
                foreach (int p in Producto)
                {
                    cotizacion = new Cotizaciones();
                    // Calcula el nuevo IdSalida del registro
                    cotizacion.IdCotizacion = 1;
                    if (ListaCotizaciones.Count > 0)
                        cotizacion.IdCotizacion = ListaCotizaciones.Max(x => x.IdCotizacion) + 1;
                    // Establecemos las demas propiedades del modelo
                    cotizacion.IdProducto = p;
                    cotizacion.NumeroCotizacion = cotizacion.IdCotizacion;
                    cotizacion.Cantidad = Cantidad[cont];
                    cotizacion.Producto = ListaProducto.FirstOrDefault(x => x.IdProducto == p);
                    cotizacion.Subtotal = cotizacion.Cantidad * cotizacion.Producto.Precio * 1;
                    cotizacion.FechaRegistro = DateTime.Now;
                    cotizacion.IdCliente = Cliente[cont]; // Este valor se debe de tomar de la variable de Session["Usuario"]
                    ListaCotizaciones.Add(cotizacion);    // Agregamos el producto a la lista de salidas
                    cont++;             // Incrementa contador
                    cotizacion = null;      // Limpia el modelo para el siguiente ciclo
                }
               // db.Guardar(ListaCotizaciones);
                // Esta vista muestra los registros del modelo SalidaInventario con una plantilla de tipo List
                return RedirectToAction("Reporte");
            }
            return View();
        }

        public ActionResult Reporte()
        {
            return View(ListaCotizaciones);
        }

    }
}