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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceMarcas" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceMarcas.svc or ServiceMarcas.svc.cs at the Solution Explorer and start debugging.
    public class ServiceMarcas : IServiceMarcas
    {
        public bool agregarMarca(Marca json)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                Marca m = new Marca();
                m.Nombre = json.Nombre;
                m.Imagen = json.Imagen;

                mc.Marcas.Add(m);
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool editarMarca(Marca json)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                Marca m = mc.Marcas.Where(s=> s.Id == json.Id).FirstOrDefault();
                m.Nombre = json.Nombre;
                m.Imagen = json.Imagen;

                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarMarca(string id)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                int oid = Convert.ToInt32(id);
                Marca datos = mc.Marcas.Where(s => s.Id == oid).FirstOrDefault();
                mc.Marcas.Remove(datos);
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Marca> listarMarca()
        {
            ModelosContext mc = new ModelosContext();
            List<Marca> list = new List<Marca>();
            var li = mc.Marcas.ToList();

            foreach (Marca dt in li)
            {
                Marca p = new Marca();
                p.Id = dt.Id;
                p.Nombre = dt.Nombre;
                p.Imagen = dt.Imagen;

                list.Add(p);
            }
            mc.Dispose();
            return list;
        }

        public Marca obtenerMarcaByNombre(Marca nombre)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                Marca ma = mc.Marcas.Where(d=>d.Nombre==nombre.Nombre).FirstOrDefault();
                mc.Dispose();
                return ma;
            }
            catch (Exception)
            {

                return null; 
            }
        }

        public Marca traerMarca(string id)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                int sid = Convert.ToInt32(id);
                Marca ma = mc.Marcas.Find(sid);
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
