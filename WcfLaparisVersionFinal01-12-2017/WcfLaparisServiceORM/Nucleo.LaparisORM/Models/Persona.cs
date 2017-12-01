using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.LaparisORM.Models
{
    class Persona
    {
        [Key]
        public int _id { get; set; }
        public string _nombre { get; set; }
        public string _apellidos { get; set; }
        public string _telefono { get; set; }
        public int _edad { get; set; }
        public virtual List<Usuario> _usuarios { get; set; }





    }
}
