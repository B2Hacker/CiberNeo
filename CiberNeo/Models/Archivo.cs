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
    public class Archivo
    {
        [Key]
        public int IdArchivo { get; set; }

        [Required]
        [DisplayName("Producto")]
        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]  //Relacion con el modelo Proveedor
        public Producto Producto { get; set; }

        [Required]
        [DisplayName("Titulo")]
        public string Titulo { get; set; }

        [DisplayName("Detalles")]
        public string Detalles { get; set; }

        [Required]
        [DisplayName("Tipo de documento")]
        public string Tipo { get; set; }

        [Required]
        [DisplayName("Archivo")]
        public string Url { get; set; }
      }
    }