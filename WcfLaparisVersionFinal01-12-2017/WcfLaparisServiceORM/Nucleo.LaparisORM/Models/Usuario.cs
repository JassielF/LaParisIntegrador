using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.LaparisORM.Models
{
    class Usuario
    {
        [Key]
        public int _id { get; set; }
        public string _correo { get; set; }
        public string _password { get; set; }
        public string _tipoUser { get; set; }
        public int _userDesactivado { get; set; }

        public int _personaId { get; set; }
        public virtual Persona _Persona { get; set; }

       
    }
}
