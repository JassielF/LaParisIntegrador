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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceLogin" in both code and config file together.
    [ServiceContract]
    public interface IServiceLogin
    {
        //Login
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "login", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool comprobarUsuario(Usuario json);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "get-usuario-log", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Persona getUsuarioComprobado(string id);


    }
}
