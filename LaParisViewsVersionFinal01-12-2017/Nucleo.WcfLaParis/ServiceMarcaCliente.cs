using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Nucleo.WcfLaParis
{
   public class ServiceMarcaCliente
    {

        private string BASE_URL = "http://lplaparis.azurewebsites.net/ServiceMarcas.svc";

        public List<Marca> ListarMarca()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "/rest/listar-marca");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Marca>>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}
