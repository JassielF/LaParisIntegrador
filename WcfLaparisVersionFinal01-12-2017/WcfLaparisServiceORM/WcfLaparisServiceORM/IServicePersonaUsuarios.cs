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
    [ServiceContract]
    public interface IServicePersonaUsuarios
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "listar-info-usuarios", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Persona> listarPersonas();

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "eliminar-usuario/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool eliminarPersona(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editar-usuario", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool editarPersona(Persona json);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "crear-usuario", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool insertarPersona(Persona json);
 
        //Cambiar de cliente a admin
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "up-usuario", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool actualizarDatosUsuario(Usuario acUsuario);
    }
}
