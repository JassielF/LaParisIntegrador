using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using System.Data.Entity;
using WcfLaparisServiceORM.EntitiesModelsLP;
namespace WcfLaparisServiceORM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceProductos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceProductos.svc or ServiceProductos.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProductos : IServiceProductos
    {
        public bool agregarProducto(Producto json)
        {
            try
            {   
                ModelosContext mc = new ModelosContext();

               Categoria idCat = mc.Categorias.Where(ap => ap.Nombre == json.Categoria.Nombre).FirstOrDefault();
               Marca idMar = mc.Marcas.Where(app => app.Nombre == json.Marca.Nombre).FirstOrDefault();
               Sucursal idSuc = mc.Sucursales.Where(appp => appp.Nombre == json.Sucursal.Nombre).FirstOrDefault();
                Producto p = new Producto();
                p.Nombre = json.Nombre;
                p.Imagen = json.Imagen;
                p.Cantidad = json.Cantidad;
                p.Sku = json.Sku;
                p.Promocion = json.Promocion;
                p.Detalle = json.Detalle;
                p.idCategoria = idCat.Id;
                p.idMarca = idMar.Id;
                p.idSucursal = idSuc.Id;

                mc.Productos.Add(p);
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool editarProducto(Producto json)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                

                Producto p = mc.Productos.Where(d => d.Id == json.Id).FirstOrDefault();  
                              
                p.Nombre = json.Nombre;
                p.Imagen = json.Imagen;
                p.Cantidad = json.Cantidad;
                p.Sku = json.Sku;
                p.Promocion = json.Promocion;
                p.Detalle = json.Detalle;
                //if (json.Categoria.Nombre != null)
                //{
                //    Categoria idCat = mc.Categorias.Where(ap => ap.Nombre == json.Categoria.Nombre).FirstOrDefault();
                //    p.idCategoria = idCat.Id;
                //}
                //else
                //{
                    p.idCategoria = json.idCategoria;
                //}
                //if (json.Marca.Nombre!=null)
                //{
                //    Marca idMar = mc.Marcas.Where(app => app.Nombre == json.Marca.Nombre).FirstOrDefault();
                //    p.idMarca = idMar.Id;
                //}
                //else
                //{
                    p.idMarca = json.idMarca;
                //}
                //if (json.Sucursal.Nombre != null)
                //{
                //    Sucursal idSuc = mc.Sucursales.Where(appp => appp.Nombre == json.Sucursal.Nombre).FirstOrDefault();
                //    p.idSucursal = idSuc.Id;
                //}
                //else
                //{
                    p.idSucursal = json.idSucursal;
                //}
             
                
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarProducto(string id)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                int oid = Convert.ToInt32(id);
                Producto datos = mc.Productos.Where(s => s.Id == oid).FirstOrDefault();
                mc.Productos.Remove(datos);
                mc.SaveChanges();
                mc.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Producto> listarProducto()
        {
            ModelosContext mc = new ModelosContext();
            List<Producto> list = new List<Producto>();
            var li = mc.Productos.Include(m=> m.Marca).ToList();

            foreach (Producto dt in li)
            {
                Producto p = new Producto();
                p.Nombre = dt.Nombre;
                p.Imagen = dt.Imagen;
                p.Cantidad = dt.Cantidad;
                p.Sku = dt.Sku;
                p.Promocion = dt.Promocion;
                p.Detalle = dt.Detalle;
                p.Marca = new Marca();
                p.Marca.Nombre = dt.Marca.Nombre;
                p.Marca.Imagen = dt.Imagen;
                                
                list.Add(p);
            }
            mc.Dispose();
            return list;
        }

        public List<Producto> listarProductoMarca(string nombreMarca)
        {
            ModelosContext mc = new ModelosContext();
            List<Producto> list = new List<Producto>();
            var li = mc.Productos.Include(m => m.Marca).Where(s=> s.Marca.Nombre == nombreMarca).ToList();

            foreach (Producto dt in li)
            {
                Producto p = new Producto();
                p.Nombre = dt.Nombre;
                p.Imagen = dt.Imagen;
                p.Cantidad = dt.Cantidad;
                p.Sku = dt.Sku;
                p.Promocion = dt.Promocion;
                p.Detalle = dt.Detalle;
                p.Marca = new Marca();
                p.Marca.Nombre = dt.Marca.Nombre;
                p.Marca.Imagen = dt.Imagen;

                list.Add(p);
            }
            mc.Dispose();
            return list;
        }

        public List<Producto> listarProductoCategoria(string nombreCategoria)
        {
            ModelosContext mc = new ModelosContext();
            List<Producto> list = new List<Producto>();
            var li = mc.Productos.Include(m => m.Marca).Include(c=>c.Categoria).Where(s => s.Categoria.Nombre == nombreCategoria).ToList();

            foreach (Producto dt in li)
            {
                Producto p = new Producto();
                p.Nombre = dt.Nombre;
                p.Imagen = dt.Imagen;
                p.Cantidad = dt.Cantidad;
                p.Sku = dt.Sku;
                p.Promocion = dt.Promocion;
                p.Detalle = dt.Detalle;
                p.Marca = new Marca();
                p.Marca.Nombre = dt.Marca.Nombre;
                p.Marca.Imagen = dt.Imagen;

                list.Add(p);
            }
            mc.Dispose();
            return list;
        }
        
        public Producto buscarPorSku(Producto sku)
        {
            ModelosContext mc = new ModelosContext();
           // List<Producto> list = new List<Producto>();
            Producto p = mc.Productos.Where(pr => pr.Sku == sku.Sku).FirstOrDefault();
            //Include(m => m.Marca).Include(ca => ca.Categoria).Include(su => su.Sucursal)
            //foreach (Producto dt  in li)
            //{
                //Producto p = new Producto();
                //p.Nombre = li.Nombre;
                //p.Imagen = li.Imagen;
                //p.Cantidad = li.Cantidad;
                //p.Sku = li.Sku;
                //p.Promocion = li.Promocion;
                //p.Detalle = li.Detalle;
                //p.Marca = new Marca();
                //p.Marca.Nombre = dt.Marca.Nombre;
                //p.Sucursal = new Sucursal();
                //p.Sucursal.Nombre = dt.Sucursal.Nombre;
                //p.Categoria = new Categoria();
                //p.Categoria.Nombre = dt.Nombre;


            //    list.Add(p);
            //}
            mc.Dispose();
            return p;
           
        }

    }
}
