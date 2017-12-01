using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nucleo.WcfLaParis;

namespace LaParisWebApp1.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Marcas()
        {

            ServiceMarcaCliente sc = new ServiceMarcaCliente();
            ViewBag.listarMarca = sc.ListarMarca();


            return View();
        }
    }
}