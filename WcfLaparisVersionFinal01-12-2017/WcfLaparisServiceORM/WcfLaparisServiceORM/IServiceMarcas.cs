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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceMarcas" in both code and config file together.
    [ServiceContract]
    public interface IServiceMarcas
    {
        //CRUD PARA LAS MARCAS
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "agregar-marca", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool agregarMarca(Marca json);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "eliminar-marca/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool eliminarMarca(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editar-marca", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool editarMarca(Marca json);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "listar-marca", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Marca> listarMarca();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "buscar-marca", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Marca obtenerMarcaByNombre(Marca nombre);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "traer-marca/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Marca traerMarca(string id);
    }
}
