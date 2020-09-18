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
    public class SalidaInventario
    {
        [Key]
        public int IdSalida { get; set; }

        [Required][DisplayName("Producto")]
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public Producto producto { get; set; }


        [Required]
        public int Cantidad { get; set; }

        [Required][DisplayName("SubTotal")]
        public double Monto { get; set; }

        [Required][DisplayName("Fecha de Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:yyyy-MM-dd")]
        public DateTime FechaRegistro { get; set; }

        public int IdUsuario { get; set; }
    }
}