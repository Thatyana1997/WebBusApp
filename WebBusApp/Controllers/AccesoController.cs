using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using WebBusApp.Models;
using Dapper;

namespace WebBusApp.Controllers
{
    public class AccesoController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string email, string contrasena)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var usuario = connection.Query<Usuario>(
                     "SELECT * FROM Usuarios WHERE Email = @Email AND Contrasena = @Contrasena",
                     new { Email = email, Contrasena = contrasena }
                 ).FirstOrDefault();
                if (usuario != null)
                {
                    // Aquí puedes agregar la lógica para establecer una sesión
                    return Json(new { success = true, message = "Inicio de sesión exitoso" });
                }
                else
                {
                    return Json(new { success = false, message = "Credenciales incorrectas" });
                }
            }
        }
    }
}