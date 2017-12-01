using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Nucleo.WcfLaParis
{
    public class ServiceServicioClient
    {

        private string BASE_URL = "http://lplaparis.azurewebsites.net/ServiceServicioDetalles.svc";

        public List<Servicio> ListarServicio()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "/rest/listar-servicios-detalles");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Servicio>>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}
