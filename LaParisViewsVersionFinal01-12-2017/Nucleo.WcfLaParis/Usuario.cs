using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.WcfLaParis
{
   public class Usuario
    {
        
        public int _id { get; set; }
        public string _correo { get; set; }
        public string _password { get; set; }
        public string _tipoUser { get; set; }
        public int _userDesactivado { get; set; }

        public int _personaId { get; set; }
        public virtual Persona _Persona { get; set; }

       
    }
}
