using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBusApp.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAdicion { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string ModificadoPor { get; set; }
    }
}