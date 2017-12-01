using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nucleo.WcfLaParis;

namespace LaParisWebApp1.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: Servicios
        public ActionResult Servicio()
        {
            
            ServiceServicioClient sc = new ServiceServicioClient();
            ViewBag.listServicio = sc.ListarServicio();

            return View();
        }
    }
}