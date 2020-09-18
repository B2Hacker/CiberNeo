using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CiberNeo.Models;
using System.IO;

namespace CiberNeo.Controllers
{
    public class DBConnection
    {
        string ruta = " ";
        /// ------------------------------------------------------------------------------------------------------------------------
        //static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\David\\source\\repos\\CiberNeo\\CiberNeo\\App_Data\\Inventario.mdf;Integrated Security=True";

        //static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\B2Original\\Desktop\\CiberNeo\\CiberNeo\\App_Data\\Inventario.mdf;Integrated Security=True";

        static string connString = "Data Source=198.71.225.145;Initial Catalog=Inventario;Persist Security Info=True;User ID=AdminCiberNeo;Password=Yke1e0?9";

        SqlConnection conn = new SqlConnection(connString);
        /// ------------------------------------------------------------------------------------------------------------------------


        private bool Abrir()
        {
            try
            {
                conn.Open();
                return true; 
            }
            catch (Exception)
            {

            }
            return false;
        }

        private bool Cerrar()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        /// ------------------------------------------------------------------------------------------------------------------------

        public List<Categoria> GetCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                SqlCommand cmd = new SqlCommand("GetCategorias", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Categoria cat;
                while (dr.Read())
                {
                        cat = new Categoria();
                        cat.IdCategoria = dr.GetInt32(0);
                        cat.Nombre = dr.GetString(1);
                        lista.Add(cat);
                        cat = null;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                conn.Close();
                lista = new List<Categoria>();
            }
            return lista;
        }

        public int SetCategoria(Categoria cat, int opcion)
        {
            int res = 0;
            try
            {
                string sql = "SetCategoria";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idc", cat.IdCategoria);
                cmd.Parameters.AddWithValue("@nom", cat.Nombre);
                cmd.Parameters.AddWithValue("@op", opcion);
                conn.Open();
                res = cmd.ExecuteNonQuery();
                conn.Close();
                res = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                Cerrar();
                res = 0;
            }
            return res;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                SqlCommand cmd = new SqlCommand("GetUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Usuario user;
                while (dr.Read())
                {
                    user = new Usuario();
                    user.IdUsuario = dr.GetInt32(0); // Convert.ToInt32(dr["IdUsuario"])
                    user.Nombre = dr.GetString(1);
                    user.Paterno = dr.GetString(2);
                    user.Materno = dr.GetString(3);
                    user.CorreoElectronico = dr.GetString(4);
                    user.Username = dr.GetString(5);
                    user.Password = dr.GetString(6);
                    user.IdPerfil = dr.GetInt32(7);
                    lista.Add(user);
                    user = null;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                conn.Close();
                lista = new List<Usuario>();
            }
            return lista;
        }

        public int SetUsuario(Usuario User, int opcion)
        {
            int res = 0;
            try
            {
                string sql = "SetUsuario";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idu", User.IdUsuario);
                cmd.Parameters.AddWithValue("@nom", User.Nombre);
                cmd.Parameters.AddWithValue("@pat", User.Paterno);
                cmd.Parameters.AddWithValue("@mat", User.Materno);
                cmd.Parameters.AddWithValue("@cor", User.CorreoElectronico);
                cmd.Parameters.AddWithValue("@user", User.Username);
                cmd.Parameters.AddWithValue("@pass", User.Password);
                cmd.Parameters.AddWithValue("@idp", User.IdPerfil);
                cmd.Parameters.AddWithValue("@op", opcion);
                conn.Open();
                res = cmd.ExecuteNonQuery();
                conn.Close();
                res = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                conn.Close();
                res = 0;
            }
            return res;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        
        public List<Cliente> GetClientes()
            {
                List<Cliente> lista = new List<Cliente>();
                try
                {
                        SqlCommand cmd = new SqlCommand("GetClientes", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        Cliente cl;
                        while (dr.Read())
                        {
                            cl = new Cliente();
                            cl.IdCliente = dr.GetInt32(0);
                            cl.Nombre = dr.GetString(1);
                            cl.Correo = dr.GetString(2);
                            cl.Username = dr.GetString(3);
                            cl.Password = dr.GetString(4);
                            cl.Telefono = dr.GetString(5);
                            cl.Direccion = dr.GetString(6);
                            cl.Ciudad = dr.GetString(7);
                            lista.Add(cl);
                            cl = null;
                        }
                        conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                    Cerrar();
                    lista = new List<Cliente>();
                }
                return lista;
            }

        public int SetClientes(Cliente cl, int opcion)
        {
            int res = 0;
            try
            {
                string sql = "SetCliente";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcl", cl.IdCliente);
                cmd.Parameters.AddWithValue("@nom", cl.Nombre);
                cmd.Parameters.AddWithValue("@cor", cl.Correo);
                cmd.Parameters.AddWithValue("@user", cl.Username);
                cmd.Parameters.AddWithValue("@pass", cl.Password);
                cmd.Parameters.AddWithValue("@tel", cl.Telefono);
                cmd.Parameters.AddWithValue("@dir", cl.Direccion);
                cmd.Parameters.AddWithValue("@cd", cl.Ciudad);
                cmd.Parameters.AddWithValue("@op", opcion);
                conn.Open();
                res = cmd.ExecuteNonQuery();
                conn.Close();
                res = 1;
                }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                Cerrar();
                res = -1;
            }
            return res;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        
        public List<Perfil> GetPerfiles()
        {
            List<Perfil> lista = new List<Perfil>();
            try
            {
                    SqlCommand cmd = new SqlCommand("GetPerfiles", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Perfil per;
                    while (dr.Read())
                    {
                        per = new Perfil();
                        per.IdPerfil = dr.GetInt32(0);
                        per.Nombre = dr.GetString(1);
                        per.Descripcion = dr.GetString(2);
                        lista.Add(per);
                        per = null;
                    }
                    conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                lista = new List<Perfil>();
            }
            return lista;
        }

        public int SetPerfiles(Perfil per, int opcion)
        {
            int res = 0;
            try
            {
                string sql = "SetPerfil";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idper", per.IdPerfil);
                cmd.Parameters.AddWithValue("@nom", per.Nombre);
                cmd.Parameters.AddWithValue("@des", per.Descripcion);
                cmd.Parameters.AddWithValue("@op", opcion);
                conn.Open();
                res = cmd.ExecuteNonQuery();
                conn.Close();
                res = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                conn.Close();
                res = 0;
            }
            return res;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        
        public List<Proveedor> GetProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                SqlCommand cmd = new SqlCommand("GetProveedores", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Proveedor prov;
                while (dr.Read())
                    {
                        prov = new Proveedor();
                        prov.IdProveedor = dr.GetInt32(0);
                        prov.Nombre = dr.GetString(1);
                        prov.Direccion = dr.GetString(2);
                        prov.CorreoElectronico = dr.GetString(3);
                        prov.Telefono = dr.GetString(4);
                        lista.Add(prov);
                        prov = null;
                    }
                    conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                conn.Close();
                lista = new List<Proveedor>();
            }
            return lista;
        }

        public int SetProveedores(Proveedor prov, int opcion)
        {
            int res = 0;
            try
            {
                string sql = "SetProveedores";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idprov", prov.IdProveedor);
                cmd.Parameters.AddWithValue("@nom", prov.Nombre);
                cmd.Parameters.AddWithValue("@dir", prov.Direccion);
                cmd.Parameters.AddWithValue("@cor", prov.CorreoElectronico);
                cmd.Parameters.AddWithValue("@tel", prov.Telefono);
                cmd.Parameters.AddWithValue("@op", opcion);
                conn.Open();
                res = cmd.ExecuteNonQuery();
                conn.Close();
                res = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                Cerrar();
                res = 0;
            }
            return res;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        
        public List<Inventario> GetInventarios()
        {
            string sql = "SELECT * FROM Inventario ORDER BY Nombre";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<Inventario> lista = new List<Inventario>();
            try
            {
                if (Abrir())
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    Inventario inv;
                    while (dr.Read())
                    {
                        inv = new Inventario();
                        inv.IdInventario = dr.GetInt32(0);
                        inv.IdProducto = dr.GetInt32(1);
                        inv.IdProveedor = dr.GetInt32(2);
                        inv.Precio = dr.GetInt32(3);
                        inv.Cantidad = dr.GetInt32(4);
                        inv.FechaRegistro = dr.GetDateTime(5);
                        inv.IdUsuario = dr.GetInt32(6);
                        lista.Add(inv);
                        inv = null;
                    }
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                Cerrar();
                lista = new List<Inventario>();
            }
            return lista;
        }

        public int SetInventarios(Inventario inv, Operacion op)
        {
            int res = 0;
            string sql = "";
            switch (op)
            {
                case Operacion.Insertar:
                    sql = "INSERT INTO Inventario VALUES(@nom)";
                    break;
                case Operacion.Actualizar:
                    sql = "UPDATE Inventario SET Nombre = @nom WHERE (IdInventario = @idinv)";
                    break;
                case Operacion.Eliminar:
                    sql = "DELETE FROM Inventario WHERE (IdInventario = @idinv)";
                    break;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idinv", inv.IdInventario);
                cmd.Parameters.AddWithValue("@idpro", inv.IdProducto);
                cmd.Parameters.AddWithValue("@idprov", inv.IdProveedor); 
                cmd.Parameters.AddWithValue("@pre", inv.Precio);
                cmd.Parameters.AddWithValue("@can", inv.Cantidad);
                cmd.Parameters.AddWithValue("@Fec", inv.FechaRegistro);
                cmd.Parameters.AddWithValue("@idu", inv.IdUsuario);
                if (Abrir())
                {
                    res = cmd.ExecuteNonQuery();
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                Cerrar();
                res = -1;
            }
            return res;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        
        public List<Producto> GetProductos()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Producto pro;
                while (dr.Read())
                    {
                        pro = new Producto();
                        pro.IdProducto = dr.GetInt32(0);
                        pro.Nombre = dr.GetString(1);
                        pro.Precio = dr.GetInt32(2);
                        pro.IdCategoria = dr.GetInt32(3);
                        pro.Marca = dr.GetString(4);
                        pro.Cantidad = dr.GetInt32(5);
                        lista.Add(pro);
                        pro = null;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                conn.Close();
                lista = new List<Producto>();
            }
            return lista;
        }

        public int SetProductos(Producto pro, int opcion)
        {
            int res = 0;
            try
            {
                string sql = "SetProductos";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", pro.IdProducto);
                cmd.Parameters.AddWithValue("@nom", pro.Nombre);
                cmd.Parameters.AddWithValue("@pre", pro.Precio);
                cmd.Parameters.AddWithValue("@idc", pro.IdCategoria);
                cmd.Parameters.AddWithValue("@mar", pro.Marca);
                cmd.Parameters.AddWithValue("@can", pro.Cantidad);
                cmd.Parameters.AddWithValue("@op", opcion);
                conn.Open();
                res = cmd.ExecuteNonQuery();
                conn.Close();
                res = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Un error Inesperado a ocurrido.", ex);
                conn.Close();
                res = 0;
            }
            return res;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        
        public Usuario Login(string user, string pass)
        {
            // 4. Indicamos la operacion a realizar
            string sql = "SELECT * FROM Usuarios WHERE (Username=@user) AND (Password=@pass)";
            // 5. Creamos un objeto de comando para ejecutar la operacion y se inicializa
            SqlCommand cmd = new SqlCommand(sql, conn);
            // 6. Antes de ejecutar la consulta es necesario abrir la conexion
            conn.Open();
            // 7. Para realizar una consulta select se requiere un SqlDataReader
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataReader dr = cmd.ExecuteReader();
            // 8. Una vez que se ejecuta la consulta se requiere leer los datos obtenidos
            Usuario usuario = new Usuario();
            while (dr.Read())
            {
                usuario.IdUsuario = dr.GetInt32(0); // Convert.ToInt32(dr["IdUsuario"])
                usuario.Nombre = dr.GetString(1);
                usuario.Paterno = dr.GetString(2);
                usuario.Materno = dr.GetString(3);
                usuario.CorreoElectronico = dr.GetString(4);
                usuario.Username = dr.GetString(5);
                usuario.Password = dr.GetString(6);
                usuario.IdPerfil = dr.GetInt32(7);
            }
            conn.Close();
            return usuario;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        
        public List<SalidaInventario> GetSalidas()
        {
            string sql = "SELECT * FROM Inventario ORDER BY Nombre";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<SalidaInventario> lista = new List<SalidaInventario>();
            try
            {
                if (Abrir())
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    SalidaInventario sal;
                    while (dr.Read())
                    {
                        sal = new SalidaInventario();
                        sal.IdSalida = dr.GetInt32(0);
                        sal.IdProducto = dr.GetInt32(1);
                        //sal.producto = dr.GetInt32(2);
                        sal.Cantidad = dr.GetInt32(3);
                        sal.Monto = dr.GetDouble(4);
                        sal.FechaRegistro = dr.GetDateTime(5);
                        sal.IdUsuario = dr.GetInt32(6);
                        lista.Add(sal);
                        sal = null;
                    }
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                Cerrar();
                lista = new List<SalidaInventario>();
            }
            return lista;
        }

        public int SetSalidas(SalidaInventario sal, Operacion op)
        {
            int res = 0;
            string sql = "";
            switch (op)
            {
                case Operacion.Insertar:
                    sql = "INSERT INTO Salidas VALUES(@nom)";
                    break;
                case Operacion.Actualizar:
                    sql = "UPDATE Salidas SET Nombre = @nom WHERE (IdSalida = @idsal)";
                    break;
                case Operacion.Eliminar:
                    sql = "DELETE FROM Salidas WHERE (IdSalida = @idsal)";
                    break;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idsal", sal.IdSalida);
                cmd.Parameters.AddWithValue("@idpro", sal.IdProducto);
                cmd.Parameters.AddWithValue("@pro", sal.producto);
                cmd.Parameters.AddWithValue("@can", sal.Cantidad);
                cmd.Parameters.AddWithValue("@mon", sal.Monto);
                cmd.Parameters.AddWithValue("@fec", sal.FechaRegistro);
                cmd.Parameters.AddWithValue("@idu", sal.IdUsuario);
                if (Abrir())
                {
                    res = cmd.ExecuteNonQuery();
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                Cerrar();
                res = -1;
            }
            return res;
        }



        /// ------------------------------------------------------------------------------------------------------------------------

        public List<Archivo> GetArchivos()
        {
            string sql = "SELECT * FROM Usuarios ORDER BY Nombre";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<Archivo> lista = new List<Archivo>();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                Archivo arc;
                while (dr.Read())
                {
                    arc = new Archivo();
                    arc.IdArchivo = dr.GetInt32(0);
                    arc.IdProducto = dr.GetInt32(1);
                    //arc.Producto = dr.GetString(2);
                    arc.Titulo = dr.GetString(3);
                    arc.Detalles = dr.GetString(4);
                    arc.Tipo = dr.GetString(5);
                    arc.Url = dr.GetString(6);
                    lista.Add(arc);
                    arc = null;
                }
                Cerrar();
            }
            catch (Exception ex)
            {
                Cerrar();
                lista = new List<Archivo>();
            }
            return lista;
        }

        public int SetArchivos(Archivo arc, Operacion op)
        {
            int res = 0;
            string sql = "";
            switch (op)
            {
                case Operacion.Insertar:
                    sql = "INSERT INTO Archivos VALUES(@nom)";
                    break;
                case Operacion.Actualizar:
                    sql = "UPDATE Archivos SET Nombre = @nom WHERE (IdArchivo = @idarc)";
                    break;
                case Operacion.Eliminar:
                    sql = "DELETE FROM Productos WHERE (IdArchivo = @idarc)";
                    break;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idarc", arc.IdArchivo);
                cmd.Parameters.AddWithValue("@idpro", arc.IdProducto);
                cmd.Parameters.AddWithValue("@pro", arc.Producto);
                cmd.Parameters.AddWithValue("@tit", arc.Titulo);
                cmd.Parameters.AddWithValue("@det", arc.Detalles);
                cmd.Parameters.AddWithValue("@tip", arc.Tipo);
                cmd.Parameters.AddWithValue("@url", arc.Url);
                if (Abrir())
                {
                    res = cmd.ExecuteNonQuery();
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                Cerrar();
                res = -1;
            }
            return res;
        }

        private string LeerArchivo(string nombre)
        {
            string datos = "[]";
            try
            {
                using (StreamReader sw = new StreamReader(ruta + nombre))
                {
                    datos = sw.ReadToEnd();
                    sw.Close();
                }
            }
            catch (Exception)
            {
                datos = "[]";
            }
            return datos;
        }

        public void CrearArchivo(string datos, string nombre)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(ruta + nombre))
                {
                    sw.Write(datos);
                    sw.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------

        public List<Cotizaciones> GetCotizaciones()
        {
            string sql = "SELECT * FROM Inventario ORDER BY Nombre";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<Cotizaciones> lista = new List<Cotizaciones>();
            try
            {
                if (Abrir())
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    Cotizaciones cot;
                    while (dr.Read())
                    {
                        cot = new Cotizaciones();
                        cot.IdCotizacion = dr.GetInt32(0);
                        cot.IdCliente = dr.GetInt32 (1);
                        //cot.Cliente = dr.GetString(2);
                        cot.NumeroCotizacion = dr.GetInt32(3);
                        cot.FechaRegistro = dr.GetDateTime(4);
                        cot.IdProducto = dr.GetInt32(5);
                        //cot.Producto = dr.GetString(6);
                        cot.Cantidad = dr.GetInt32(7);
                        cot.Precio = dr.GetInt32(8);
                        cot.Subtotal = dr.GetInt32(9);
                        lista.Add(cot);
                        cot = null;
                    }
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                Cerrar();
                lista = new List<Cotizaciones>();
            }
            return lista;
        }

        public int SetCotizaciones(Cotizaciones cot, Operacion op)
        {
            int res = 0;
            string sql = "";
            switch (op)
            {
                case Operacion.Insertar:
                    sql = "INSERT INTO Cotizaciones VALUES(@nom)";
                    break;
                case Operacion.Actualizar:
                    sql = "UPDATE Cotizaciones SET Nombre = @nom WHERE (IdCotizacion = @idcot)";
                    break;
                case Operacion.Eliminar:
                    sql = "DELETE FROM Salidas WHERE (IdCotizacion = @idcot)";
                    break;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idcot", cot.IdCotizacion);
                cmd.Parameters.AddWithValue("@idc", cot.IdCliente);
                cmd.Parameters.AddWithValue("@cl", cot.Cliente);
                cmd.Parameters.AddWithValue("@num", cot.NumeroCotizacion);
                cmd.Parameters.AddWithValue("@fec", cot.FechaRegistro);
                cmd.Parameters.AddWithValue("@idpro", cot.IdProducto);
                cmd.Parameters.AddWithValue("@pro", cot.Producto);
                cmd.Parameters.AddWithValue("@can", cot.Cantidad);
                cmd.Parameters.AddWithValue("@pre", cot.Precio);
                cmd.Parameters.AddWithValue("@sub", cot.Subtotal);
                if (Abrir())
                {
                    res = cmd.ExecuteNonQuery();
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                Cerrar();
                res = -1;
            }
            return res;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
    }

    public enum Operacion
    {
        Insertar,
        Actualizar,
        Eliminar
    }
}