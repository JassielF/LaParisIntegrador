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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceSucursal" in both code and config file together.
    [ServiceContract]
    public interface IServiceSucursal
    {

        //CRUD PARA LAS SUCURSALES
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "agregar-sucursal", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool agregarSucursal(Sucursal json);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "eliminar-sucursal/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool eliminarSucursal(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editar-sucursal", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool editarSucursal(Sucursal json);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "listar-sucursales", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Sucursal> listarSucursal();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "buscar-sucursal", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Sucursal obtenerSucursalByNombre(Sucursal nombre);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "traer-sucursal/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Sucursal traerSucursal(string id);
    }
}
