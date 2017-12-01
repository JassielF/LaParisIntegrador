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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceCategorias" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceCategorias.svc or ServiceCategorias.svc.cs at the Solution Explorer and start debugging.
    public class ServiceCategorias : IServiceCategorias
    {
        public bool agregarCategoria(Categoria json)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                Categoria a = new Categoria();
                a.Nombre = json.Nombre;
                               
                mc.Categorias.Add(a);
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool editarCategoria(Categoria json)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                Categoria a = mc.Categorias.Where(sd => sd.Id == json.Id).FirstOrDefault();
                a.Nombre = json.Nombre;
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public string eliminarCategoria(string id)
        //{
        //    try
        //    {
        //        ModelosContext mc = new ModelosContext();
        //        int sId = Convert.ToInt32(id);

        //        Categoria datos = mc.Categorias.Where(sd => sd.Id == sId).FirstOrDefault();

        //        mc.Categorias.Remove(datos);

        //        mc.SaveChanges();
        //        return "true";
        //    }
        //    catch (Exception r)
        //    {
        //        return r.Message;
        //    }
        //}

        public bool eliminarCategoriaporId(string id)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                int oid = Convert.ToInt32(id);
                Categoria datos = mc.Categorias.Where(s => s.Id == oid).FirstOrDefault();
                mc.Categorias.Remove(datos);
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Categoria> listarCategoria()
        {
            ModelosContext mc = new ModelosContext();
            List<Categoria> list = new List<Categoria>();
            var li = mc.Categorias.ToList();

            foreach (Categoria dt in li)
            {
                Categoria p = new Categoria();
                p.Id = dt.Id;
                p.Nombre = dt.Nombre;
                
                list.Add(p);

            }
            mc.Dispose();
            return list;
        }

        public Categoria obtenerCategoriaByNombre(Categoria nombre)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
               Categoria ma = mc.Categorias.Where(d => d.Nombre == nombre.Nombre).FirstOrDefault();
                mc.Dispose();
                return ma;

            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public Categoria traerSucursal(string id)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                int sid = Convert.ToInt32(id);
                Categoria ma = mc.Categorias.Find(sid);
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
