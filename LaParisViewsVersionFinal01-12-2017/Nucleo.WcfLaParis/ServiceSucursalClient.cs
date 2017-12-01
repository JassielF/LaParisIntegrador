using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Nucleo.WcfLaParis
{
    public class ServiceSucursalClient
    {

        private string BASE_URL = "http://lplaparis.azurewebsites.net/ServiceSucursal.svc";

        public List<Sucursal> ListarSucursal()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "/rest/listar-sucursales");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Sucursal>>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}
