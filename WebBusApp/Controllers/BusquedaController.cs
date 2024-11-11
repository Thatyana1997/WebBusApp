using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebBusApp.Models;

namespace WebBusApp.Controllers
{
    public class BusquedaController : Controller
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        // GET: Busqueda
        public ActionResult BuscarRuta()
        {
            return View();
        }

        [HttpPost]
        public JsonResult BuscarRutas(string origen, string destino, DateTime fecha)
        {
            var rutas = new List<Ruta>();  // Lista para almacenar las rutas encontradas

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Ejecuta la consulta SQL con los parámetros usando Dapper
                rutas = connection.Query<Ruta>(
                    "SELECT * FROM Rutas WHERE Origen = @Origen AND Destino = @Destino AND CAST(Horario AS DATE) = @Fecha",
                    new { Origen = origen, Destino = destino, Fecha = fecha.Date }
                ).ToList();
            }

            // Retorna las rutas encontradas en formato JSON
            return Json(rutas);
        }

    }
}