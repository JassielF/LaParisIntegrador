using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nucleo.WcfLaParis;

namespace LaParisWebApp1.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Establecimientos()
        {

            ServiceSucursalClient sc = new ServiceSucursalClient();
            ViewBag.listSucursal = sc.ListarSucursal();

            return View();
        }
    }
}