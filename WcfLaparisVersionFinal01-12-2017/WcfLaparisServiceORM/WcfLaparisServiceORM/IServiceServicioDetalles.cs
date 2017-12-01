using Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfLaparisServiceORM
{
    [ServiceContract]
    public interface IServiceServicioDetalles
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "listar-servicios-detalles", ResponseFormat = WebMessageFormat.Json)]
        List<Servicio> listarServicioDetalles();

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "eliminar-servicio/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool eliminarServicioDetalles(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editar-servicio", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool editarServicioDetalles(Servicio json);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "agregar-servicio", RequestFormat = WebMessageFormat.Json)]//
        bool insertarServicioDetalle(Servicio json);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "servicio-de/{nombre}", ResponseFormat = WebMessageFormat.Json)]
        List<Servicio> obtenerServicioDetalleNombre(string nombre);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "obtener-servicio-id/{id}", ResponseFormat = WebMessageFormat.Json)]
        List<Servicio> obtenerServicioById(string id);
    }
}

