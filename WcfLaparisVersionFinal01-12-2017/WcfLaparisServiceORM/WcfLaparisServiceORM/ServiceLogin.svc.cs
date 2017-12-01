using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using WcfLaparisServiceORM.EntitiesModelsLP;
using System.Data.Entity;
using System.Security.Cryptography;

namespace WcfLaparisServiceORM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceLogin" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceLogin.svc or ServiceLogin.svc.cs at the Solution Explorer and start debugging.
    public class ServiceLogin : IServiceLogin
    {
        public bool comprobarUsuario(Usuario json)
        {
           
            try
            {                
                ModelosContext mc = new ModelosContext();
                Usuario log = mc.Usuarios.Where(c => c.Correo == json.Correo && c.Password == SHA256Encrypt(json.Password)).FirstOrDefault();
                if (log != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public Persona getUsuarioComprobado(string id)
        {
            Persona p = new Persona();
            try
            {
                int oId= Convert.ToInt32(id);
                ModelosContext mc = new ModelosContext();
                p = mc.Personas.Include(u => u.Usuario).Where(pe => pe.Id == oId).FirstOrDefault();
                return p;
            }
            catch (Exception)
            {

                throw;
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
    }
}
//ModelosContext mc = new ModelosContext();
//Usuario log = mc.Usuarios.Where(c => c.Correo == json.Correo && c.Password == json.Password).FirstOrDefault();
//                if (log != null)
//                {
//                    d = mc.Personas.Include(u => u.Usuario).Where(p => p.idUsuario == log.Id).FirstOrDefault();
//                }
//                else
//                {
//                    d = null;
//                }
//                return d;