using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CiberNeo.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        [DisplayName("Proveedor")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [Required]
        [DisplayName("Correo Electrónico")]
        [MaxLength(100)]
        public string CorreoElectronico { get; set; }

        [Required]
        [DisplayName("Teléfono")]
        [MaxLength(15)]
        public string Telefono { get; set; }
    }
}