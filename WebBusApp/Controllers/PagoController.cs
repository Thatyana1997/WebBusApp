using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace WebBusApp.Controllers
{
    public class PagoController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        // GET: Pago
        public ActionResult Pagando()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ProcesarPago(int reservaId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Verificar si la reserva existe
                var sqlReserva = "SELECT EstadoPago FROM Reservas WHERE ReservaID = @ReservaID";
                var estadoPago = connection.Query<string>(sqlReserva, new { ReservaID = reservaId }).FirstOrDefault();

                if (estadoPago == null)
                {
                    return Json(new { success = false, message = "Reserva no encontrada" });
                }

                if (estadoPago == "Pagado")
                {
                    return Json(new { success = false, message = "La reserva ya ha sido pagada" });
                }

                // Actualizar el estado de pago de la reserva
                var sqlUpdate = @"
            UPDATE Reservas
            SET EstadoPago = 'Pagado', FechaModificacion = @FechaModificacion, ModificadoPor = @ModificadoPor
            WHERE ReservaID = @ReservaID";

                connection.Execute(sqlUpdate, new
                {
                    FechaModificacion = DateTime.Now,
                    ModificadoPor = "Sistema", // Puedes asignar un valor adecuado para "ModificadoPor"
                    ReservaID = reservaId
                });

                // Retornar respuesta JSON
                return Json(new { success = true, message = "Pago procesado exitosamente", reservaId = reservaId });
            }
        }
    }
}