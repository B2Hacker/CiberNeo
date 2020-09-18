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
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Correo Electronico")]
        public string Correo { get; set; }

        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [Required]
        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [Required]
        [DisplayName("Ciudad")]
        public string Ciudad { get; set; }
    }
}