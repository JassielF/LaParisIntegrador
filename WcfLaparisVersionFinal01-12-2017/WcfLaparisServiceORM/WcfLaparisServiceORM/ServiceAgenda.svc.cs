using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;
using Models;
using WcfLaparisServiceORM.EntitiesModelsLP;
namespace WcfLaparisServiceORM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceAgenda" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceAgenda.svc or ServiceAgenda.svc.cs at the Solution Explorer and start debugging.
    public class ServiceAgenda : IServiceAgenda
    {
        public bool editarAgenda(Agenda agenda)
        {
            throw new NotImplementedException();
        }

        public string agregarAgenda(Agenda agenda)
        {
            ModelosContext mc = new ModelosContext();
            try
            {
                Agenda a = new Agenda();
                a.FechaRegistro = agenda.FechaRegistro;
                a.idPersona = agenda.idPersona;
                a.idServicio = agenda.idServicio;
                mc.Agendas.Add(a);
                mc.SaveChanges();
                return "true";
            }
            catch (Exception r)
            {
                return r.Message;
            }
        }

        public bool eliminarAgenda(string id)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                int sId = Convert.ToInt32(id);
                Agenda datos = mc.Agendas.Where(sd => sd.Id == sId).FirstOrDefault();
                mc.Agendas.Remove(datos);
                mc.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Agenda> listarAgenda()
        {
            ModelosContext mc = new ModelosContext();
            List<Agenda> list = new List<Agenda>();
            var li = mc.Agendas.Include(sr => sr.Servicio).Include(pr => pr.Persona).ToList();
            
            foreach (Agenda dt in li)
            {
                Agenda p = new Agenda();
                p.Id = dt.Id;
                p.FechaRegistro = dt.FechaRegistro;
                p.Persona = new Persona();
                p.Persona.Nombre = dt.Persona.Nombre;
                p.Persona.Apellidos = dt.Persona.Apellidos;
                p.Persona.Edad = dt.Persona.Edad;
                p.Persona.Telefono = dt.Persona.Telefono;
                p.Servicio = new Servicio();
                p.Servicio.Nombre = dt.Servicio.Nombre;
                p.Servicio.Precio = dt.Servicio.Precio;                

                list.Add(p);
            }

            return list;
        }
    }
}
//from u in mc.Agendas

//                      join v in mc.Servicios
//                      on u.idServicio equals v.Id

//                      join x in mc.Agendas
//                      on u.idPersona equals x.Id

//                      join z in mc.Personas
//                      on u.idPersona equals z.Id
//                      select new
//                      {
//                          ID = u.Id,
//                          FechaRegistro= u.FechaRegistro,
//                          NombreServicio = v.Nombre,
//                          Precio = v.Precio,
//                          NombreUsuario = z.Nombre,
//                          Apellidos =z.Apellidos,
//                          Edad= z.Edad, 
//                          Telefono = z.Telefono
//                      };