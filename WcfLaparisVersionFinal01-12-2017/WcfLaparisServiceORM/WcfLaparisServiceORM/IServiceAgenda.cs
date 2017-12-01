using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using System.ServiceModel.Web;

namespace WcfLaparisServiceORM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceAgenda" in both code and config file together.
    [ServiceContract]
    public interface IServiceAgenda
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "agregar-agenda", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string agregarAgenda(Agenda agenda);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "eliminar-agenda", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool eliminarAgenda(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editar-agenda", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool editarAgenda(Agenda agenda);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "listar-agenda", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Agenda> listarAgenda();
    }
}
