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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceProductos" in both code and config file together.
    [ServiceContract]
    public interface IServiceProductos
    {
        //CRUD PARA LAS CATEGORIAS
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "agregar-producto", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool agregarProducto(Producto json);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "eliminar-producto/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool eliminarProducto(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editar-producto", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool editarProducto(Producto json);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "listar-productos", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Producto> listarProducto();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "listar-productos-categoria/{nombreCategoria}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Producto> listarProductoCategoria(string nombreCategoria);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "listar-productos-marca", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Producto> listarProductoMarca(string nombreMarca);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "obtener-producto", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Producto buscarPorSku(Producto sku);
    }
}
