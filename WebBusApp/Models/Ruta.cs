using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBusApp.Models
{
    public class Ruta
    {
        public int RutaID { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime Horario { get; set; }
        public decimal Precio { get; set; }
        public int Disponibilidad { get; set; }
    }
}