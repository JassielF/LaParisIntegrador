using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;
using WcfLaparisServiceORM.EntitiesModelsLP;


namespace WcfLaparisServiceORM
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class ServiceServicioDetalles : IServiceServicioDetalles
    {
        
        public bool eliminarServicioDetalles(string id)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                int sId = Convert.ToInt32(id);
                                
                Servicio datos = mc.Servicios.Include(d => d.DetalleServicio).Where(sd => sd.Id == sId).FirstOrDefault();
                DetalleServicio datos2 = mc.Detalles.Where(d => d.Id == datos.idDetalle).FirstOrDefault();
                mc.Servicios.Remove(datos);
                mc.Detalles.Remove(datos2);
                mc.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool editarServicioDetalles(Servicio json)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                Servicio s = mc.Servicios.Include(d => d.DetalleServicio).Where(sd => sd.Id == json.Id).FirstOrDefault();
                s.Nombre = json.Nombre;
                s.Precio = json.Precio;
                s.DetalleServicio.Descripcion = json.DetalleServicio.Descripcion;
                s.DetalleServicio.FechaInicio = json.DetalleServicio.FechaInicio;
                s.DetalleServicio.HoraInicio = json.DetalleServicio.HoraInicio;
                s.DetalleServicio.HoraTermino = json.DetalleServicio.HoraTermino;
                s.DetalleServicio.Promocion = json.DetalleServicio.Promocion;
                s.DetalleServicio.Mensaje = json.DetalleServicio.Mensaje;
                s.DetalleServicio.Total = json.DetalleServicio.Total;
                               
                mc.SaveChanges();                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
                
        public bool insertarServicioDetalle(Servicio json)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                Servicio s = new Servicio();
                s.Nombre = json.Nombre;
                s.Precio = json.Precio;
                s.DetalleServicio = new DetalleServicio();
                s.DetalleServicio.Descripcion = json.DetalleServicio.Descripcion;
                s.DetalleServicio.FechaInicio = json.DetalleServicio.FechaInicio;
                s.DetalleServicio.HoraInicio = json.DetalleServicio.HoraInicio;
                s.DetalleServicio.HoraTermino = json.DetalleServicio.HoraTermino;
                s.DetalleServicio.Promocion = json.DetalleServicio.Promocion;
                s.DetalleServicio.Mensaje = json.DetalleServicio.Mensaje;
                s.DetalleServicio.Total = json.DetalleServicio.Total;
                mc.Servicios.Add(s);
                mc.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
                
        public List<Servicio> obtenerServicioDetalleNombre(string nombre)
        {
            ModelosContext mc = new ModelosContext();
            List<Servicio> list = new List<Servicio>();
            var datos = mc.Servicios.Include(d => d.DetalleServicio).Where(lp => lp.Nombre == nombre).ToList();
            foreach (Servicio se in datos)
            {
                Servicio s = new Servicio();
                s.Id = se.Id;
                s.Nombre = se.Nombre;
                s.Precio = se.Precio;
                s.idDetalle = se.idDetalle;
                s.DetalleServicio = new DetalleServicio();
                s.DetalleServicio.Descripcion = se.DetalleServicio.Descripcion;
                s.DetalleServicio.FechaInicio = se.DetalleServicio.FechaInicio;
                s.DetalleServicio.HoraInicio = se.DetalleServicio.FechaInicio;
                s.DetalleServicio.HoraTermino = se.DetalleServicio.HoraTermino;
                s.DetalleServicio.Promocion = se.DetalleServicio.Promocion;
                s.DetalleServicio.Total = se.DetalleServicio.Total;
                s.DetalleServicio.Mensaje = se.DetalleServicio.Mensaje;

                list.Add(s);

            }
            return list;
        }

        public List<Servicio> obtenerServicioById(string id)
        {
            int sId = Convert.ToInt32(id);
            using (ModelosContext mc = new ModelosContext())
            {
                List<Servicio> list = new List<Servicio>();
                var datos = mc.Servicios.Include(d => d.DetalleServicio).Where(sd => sd.Id == sId).ToList();

                foreach (Servicio se in datos)
                {
                    Servicio s = new Servicio();
                    s.Id = se.Id;
                    s.Nombre = se.Nombre;
                    s.Precio = se.Precio;
                    s.idDetalle = se.idDetalle;
                    s.DetalleServicio = new DetalleServicio();
                    s.DetalleServicio.Descripcion = se.DetalleServicio.Descripcion;
                    s.DetalleServicio.FechaInicio = se.DetalleServicio.FechaInicio;
                    s.DetalleServicio.HoraInicio = se.DetalleServicio.FechaInicio;
                    s.DetalleServicio.HoraTermino = se.DetalleServicio.HoraTermino;
                    s.DetalleServicio.Promocion = se.DetalleServicio.Promocion;
                    s.DetalleServicio.Total = se.DetalleServicio.Total;
                    s.DetalleServicio.Mensaje = se.DetalleServicio.Mensaje;

                    list.Add(s);

                }
                return list;
            }
        }

        public List<Servicio> listarServicioDetalles()
        {
            ModelosContext mc = new ModelosContext();
            List<Servicio> list = new List<Servicio>();
            var li = mc.Servicios.Include(e => e.DetalleServicio).ToList();
            foreach (Servicio se in li)
            {
                Servicio s = new Servicio();
                s.Id = se.Id;
                s.Nombre = se.Nombre;
                s.Precio = se.Precio;
                s.idDetalle = se.idDetalle;
                s.DetalleServicio = new DetalleServicio();
                s.DetalleServicio.Descripcion = se.DetalleServicio.Descripcion;
                s.DetalleServicio.FechaInicio = se.DetalleServicio.FechaInicio;
                s.DetalleServicio.HoraInicio = se.DetalleServicio.FechaInicio;
                s.DetalleServicio.HoraTermino = se.DetalleServicio.HoraTermino;
                s.DetalleServicio.Promocion = se.DetalleServicio.Promocion;
                s.DetalleServicio.Total = se.DetalleServicio.Total;
                s.DetalleServicio.Mensaje = se.DetalleServicio.Mensaje;

                list.Add(s);
            }

            return list;
        }

    }
}

