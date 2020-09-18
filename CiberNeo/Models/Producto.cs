using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CiberNeo.Models
{   
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [DisplayName("Producto")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Precio")]
        [DataType(DataType.Currency)]
        public int Precio { get; set; }

        [Required]
        [DisplayName("Categoría")]
        public int IdCategoria { get; set; }

        [Required]
        [DisplayName("Marca")]
        public string Marca { get; set; }

        [Required]
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }

        //============= Relaciones

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
    }
}