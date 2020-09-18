using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CiberNeo.Models;

namespace CiberNeo.Models
{
    public class Cotizaciones
    {
        [Key]
        public int IdCotizacion { get; set; }

        [Required]
        [DisplayName("IdCliente")]
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [Required]
        [DisplayName("NumeroCotizacion")]
        public int NumeroCotizacion { get; set; }

        [Required]
        [DisplayName("FechaRegistro")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [DisplayName("IdProducto")]
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }

        [Required]
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }

        [Required]
        [DisplayName("Precio")]
        public int Precio { get; set; }

        [Required]
        [DisplayName("Subtotal")]
        public int Subtotal { get; set; }
    }
}