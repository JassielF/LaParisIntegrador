using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using WcfLaparisServiceORM.EntitiesModelsLP;
using System.Security.Cryptography;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
namespace WcfLaparisServiceORM
{
    public class ServicePersonaUsuarios : IServicePersonaUsuarios
    {
        public bool editarPersona(Persona json)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                Persona s = mc.Personas.Include(d => d.Usuario).Where(sd => sd.Id == json.Id).FirstOrDefault();
                s.Nombre = json.Nombre;
                s.Apellidos = json.Apellidos;
                s.Edad = json.Edad;
                s.Telefono = json.Telefono;
                s.Usuario.Correo = json.Usuario.Correo;
                s.Usuario.Password = SHA256Encrypt(json.Usuario.Password);
                s.Usuario.TipoUser = json.Usuario.TipoUser;
                s.Usuario.UserActivado = json.Usuario.UserActivado;

                mc.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
      
        public bool eliminarPersona(string id)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                int sId = Convert.ToInt32(id);
                Persona datos = mc.Personas.Include(u => u.Usuario).Where(sd => sd.Id == sId).FirstOrDefault();
                Usuario datos2 = mc.Usuarios.Where(d => d.Id == datos.idUsuario).FirstOrDefault();
                mc.Personas.Remove(datos);
                mc.Usuarios.Remove(datos2);
                mc.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool insertarPersona(Persona json)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                //crea una persona y usuario nuevo
                Persona p = new Persona();
                p.Nombre = json.Nombre;
                p.Apellidos = json.Apellidos;
                p.Telefono = json.Telefono;
                p.Edad = json.Edad;
                p.Usuario = new Usuario();
                p.Usuario.Correo = json.Usuario.Correo;                
                p.Usuario.Password = SHA256Encrypt(json.Usuario.Password);
                //p.Usuario.TipoUser = inPersona.Usuario.TipoUser;
                //p.Usuario.UserActivado = inPersona.Usuario.UserActivado;
                mc.Personas.Add(p);
                if (mc.SaveChanges()>0)
                {
                    Execute(json.Usuario.Correo, json.Nombre).Wait();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Persona> listarPersonas()
        {
            ModelosContext mc = new ModelosContext();
            List<Persona> list = new List<Persona>();
            var li = mc.Personas.Include(e => e.Usuario).ToList();
            foreach (Persona persona in li)
            {
                Persona p = new Persona();
                p.Id = persona.Id;
                p.Nombre = persona.Nombre;
                p.Apellidos = persona.Apellidos;
                p.Telefono = persona.Telefono;
                p.Edad = persona.Edad;
                p.idUsuario = persona.idUsuario;
                p.Usuario = new Usuario();
                p.Usuario.Id = persona.Usuario.Id;
                p.Usuario.Correo = persona.Usuario.Correo;
                p.Usuario.Password = persona.Usuario.Password;
                p.Usuario.TipoUser = persona.Usuario.TipoUser;
                p.Usuario.UserActivado = persona.Usuario.UserActivado;             

                list.Add(p);
            }

            return list;
        }

        // Metodos para uso del admin para actualizacion de la cuenta de usuario
        public bool actualizarDatosUsuario(Usuario acUsuario)
        {
            try
            {
                ModelosContext mc = new ModelosContext();
                Usuario s = mc.Usuarios.Where(sd => sd.Id == acUsuario.Id).FirstOrDefault();
                s.TipoUser = acUsuario.TipoUser;
                s.UserActivado = acUsuario.UserActivado;
                mc.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string SHA256Encrypt(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        
        static async Task Execute(string mail, string nombre)
        {
           string apiKey= "";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("isw.manuellozano@gmail.com", "LaParis Inmobiliáría y Productos de Belleza");
            var subject = "Registro de usuario";
            var to = new EmailAddress(mail, nombre);
            var plainTextContent = "Te damos la bienvenida";
            var htmlContent = "<strong>Para activar tu cuenta accede al siguiente enlace: </strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}



 