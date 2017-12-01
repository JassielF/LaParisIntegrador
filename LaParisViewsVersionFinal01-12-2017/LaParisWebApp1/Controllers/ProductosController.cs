using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nucleo.WcfLaParis;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using LaParisWebApp1.ViewModels;

namespace LaParisWebApp1.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Catalogo
        public ActionResult Productos()
        {
            //    List<Producto> product = new List<Producto>();
            //    string urlAction = String.Format("/ServiceProductos.svc/rest/listar-productos");
            //    product = await GetWSObject<Producto>(urlAction);

            ServiceProductClient sc = new ServiceProductClient();
            ViewBag.listProducto = sc.ListarProducto();

            //ViewData["productos"] = sc.ListarProducto();



            return View();
            //WebClient proxy = new WebClient();
            //byte[] data = proxy.DownloadData("http://lplaparis.azurewebsites.net/ServiceProductos.svc/rest/listar-productos");
            //Stream stream = new MemoryStream(data);
            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(Producto));

            //var re = obj.ReadObject(stream) as Producto;
            //string Result = obj.ReadObject(stream).ToString();



            //List<Categoria> c = new List<Categoria>();
            ////c.Add(new Categoria("Nombre"));
            //c.Add(new Categoria("Nombre"));
            //c.Add(new Categoria("Nombre"));
            //c.Add(new Categoria("Nombre"));
            //c.Add(new Categoria("Nombre"));
            //c.Add(new Categoria("Nombre"));

            //ViewData["categoria"] = Result.ToList();


            //List<Producto> p = new List<Producto>();


            

            
        }



        //public async Task<T> GetWSObject<T>(string uriActionString)
        //{
        //    T returnValue =
        //    default(T);
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(@ "http://lplaparis.azurewebsites.net");
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            HttpResponseMessage response = await client.GetAsync(uriActionString);
        //            response.EnsureSuccessStatusCode();
        //            returnValue = JsonConvert.DeserializeObject<T>(((HttpResponseMessage)response).Content.ReadAsStringAsync().Result);
        //        }
        //        return returnValue;
        //    }
        //    catch (Exception e)
        //    {
        //        throw (e);

        //    }
        //}

    }
}