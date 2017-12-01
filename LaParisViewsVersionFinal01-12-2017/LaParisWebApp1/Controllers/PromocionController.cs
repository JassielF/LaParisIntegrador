using Nucleo.WcfLaParis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaParisWebApp1.Controllers
{
    public class PromocionController : Controller
    {
        // GET: Promocion
        public ActionResult Promociones()
        {
            ServiceProductClient sc = new ServiceProductClient();
            ViewBag.listProducto = sc.ListarProducto();
            return View();
        }
    }
}