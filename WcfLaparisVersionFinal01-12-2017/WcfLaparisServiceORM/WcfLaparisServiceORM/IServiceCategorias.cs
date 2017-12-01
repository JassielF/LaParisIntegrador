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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceCategorias" in both code and config file together.
    [ServiceContract]
    public interface IServiceCategorias
    {
        //CRUD PARA LAS CATEGORIAS
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "agregar-categoria", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool agregarCategoria(Categoria json);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editar-categoria", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool editarCategoria(Categoria json);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "listar-categorias", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Categoria> listarCategoria();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "buscar-categoria", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Categoria obtenerCategoriaByNombre(Categoria nombre);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "eliminar-categoria/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool eliminarCategoriaporId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "traer-categoria/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Categoria traerSucursal(string id);
    }
}
