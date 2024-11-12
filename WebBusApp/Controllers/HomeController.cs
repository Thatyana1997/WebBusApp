using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBusApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Datos de la desarrolladora";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BuscarRuta()
        {
            ViewBag.Message = "BuscarRuta la ruta";

            return View();
        }

        public ActionResult Pagando()
        {
            ViewBag.Message = "Pagando...";

            return View();
        }

        public ActionResult ReservarRuta()
        {
            ViewBag.Message = "ReservarRuta...";

            return View();
        }
    }
}