using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using WcfLaparisServiceORM.EntitiesModelsLP;

namespace WcfLaparisServiceORM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceSucursal" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceSucursal.svc or ServiceSucursal.svc.cs at the Solution Explorer and start debugging.
    public class ServiceSucursal : IServiceSucursal
    {
        public bool agregarSucursal(Sucursal json)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                Sucursal a = new Sucursal();
                a.Nombre = json.Nombre;
                a.Telefono = json.Telefono;
                a.Direccion = json.Direccion;
                a.CodPostal = json.CodPostal;
                a.Correo = json.Correo;
                a.Telefono = json.Telefono;
                
                mc.Sucursales.Add(a);
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception r)
            {
                return false;
            }
        }

        public bool editarSucursal(Sucursal json)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                Sucursal a = mc.Sucursales.Where(sd => sd.Id == json.Id).FirstOrDefault();
                a.Nombre = json.Nombre;
                a.Telefono = json.Telefono;
                a.Direccion = json.Direccion;
                a.CodPostal = json.CodPostal;
                a.Correo = json.Correo;
                a.Telefono = json.Telefono;
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarSucursal(string id)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                int sId = Convert.ToInt32(id);
                Sucursal datos = mc.Sucursales.Where(sd => sd.Id == sId).FirstOrDefault();
                mc.Sucursales.Remove(datos);
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Sucursal> listarSucursal()
        {
            ModelosContext mc = new ModelosContext();
            List<Sucursal> list = new List<Sucursal>();
            var li = mc.Sucursales.ToList();

            foreach (Sucursal dt in li)
            {
                Sucursal a = new Sucursal();
                a.Id = dt.Id;
                a.Nombre = dt.Nombre;
                a.Telefono = dt.Telefono;
                a.Direccion = dt.Direccion;
                a.CodPostal = dt.CodPostal;
                a.Correo = dt.Correo;
                a.Telefono = dt.Telefono;

                list.Add(a);
            }
            mc.Dispose();
            return list;
        }

        public Sucursal obtenerSucursalByNombre(Sucursal nombre)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                Sucursal ma = mc.Sucursales.Where(d => d.Nombre == nombre.Nombre).FirstOrDefault();
                mc.Dispose();
                return ma;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Sucursal traerSucursal(string id)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                int sid = Convert.ToInt32(id);
                Sucursal ma = mc.Sucursales.Find(sid);
                mc.Dispose();
                return ma;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
