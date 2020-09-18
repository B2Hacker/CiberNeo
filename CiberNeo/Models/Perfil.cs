using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CiberNeo.Models
{
    public class Perfil
    {
        [Key]
        public int IdPerfil { get; set; }

        [Required]
        [DisplayName("Perfil")]
        [MaxLength(30)]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
    }
}