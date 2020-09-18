using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CiberNeo.Models
{
    [Table("Usuarios")] //Este atributo determina el nombre de la tabla en SQL
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "*********")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Apellido Paterno")]
        public string Paterno { get; set; }

        [Required]
        [DisplayName("Apellido Materno")]
        public string Materno { get; set; }

        [Required]
        [DisplayName("Correo electronico")]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

        [Required]
        [DisplayName("Nombre de Usuario")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Tipo de Usuario")]
        public int IdPerfil { get; set; }

    }
}