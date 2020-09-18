using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CiberNeo.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        [DisplayName("Categoría")]
        public string Nombre { get; set; }

    }
}