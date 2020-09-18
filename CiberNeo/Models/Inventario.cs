using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiberNeo.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CiberNeo.Models
{
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }



        [Required] [DisplayName("Producto")]
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]   //Relacion con el modelo Producto
        public Producto producto { get; set; }



        [Required] [DisplayName("Proveedor")]
        public int IdProveedor { get; set; }
        [ForeignKey("IdProveedor")]  //Relacion con el modelo Proveedor
        public Proveedor proveedor { get; set; }


        public double Precio { get; set; }
        public int Cantidad { get; set; }


        [Required][DisplayName("Fecha de ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-dd")]
        public DateTime FechaRegistro { get; set; }


        public int IdUsuario { get; set; }
    }
}