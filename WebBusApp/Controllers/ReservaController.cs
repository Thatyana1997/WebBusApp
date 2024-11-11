using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBusApp.Models;

namespace WebBusApp.Controllers
{
    public class ReservaController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        // GET: Reserva
        public ActionResult ReservarRuta()
        {
            return View();
        }



        [HttpPost]
        public JsonResult RealizarReserva(int rutaId, string asiento, int usuarioId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insertar la reserva usando Dapper
                var sql = @"
            INSERT INTO Reservas (UsuarioID, RutaID, Asiento, EstadoPago, FechaAdicion, AdicionadoPor)
            VALUES (@UsuarioID, @RutaID, @Asiento, 'Pendiente', @FechaAdicion, @AdicionadoPor);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var reservaId = connection.Query<int>(sql, new
                {
                    UsuarioID = usuarioId,
                    RutaID = rutaId,
                    Asiento = asiento,
                    FechaAdicion = DateTime.Now,
                    AdicionadoPor = usuarioId
                }).Single();

                // Retornar respuesta JSON
                return Json(new { success = true, message = "Reserva realizada exitosamente", reservaId = reservaId });
            }
        }
    }
}