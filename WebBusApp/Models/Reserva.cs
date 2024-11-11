using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBusApp.Models
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public int UsuarioID { get; set; }
        public int RutaID { get; set; }
        public string Asiento { get; set; }
        public string EstadoPago { get; set; } 
    }
}