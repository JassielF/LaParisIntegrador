using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Nucleo.WcfLaParis
{
    public class ServiceProductClient
    {

        private string BASE_URL = "http://lplaparis.azurewebsites.net/ServiceProductos.svc";

        public List<Producto> ListarProducto() {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "/rest/listar-productos");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Producto>>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
