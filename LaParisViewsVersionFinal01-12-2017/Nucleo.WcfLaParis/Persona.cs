using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.WcfLaParis
{
   public class Persona
    {
        public int _id { get; set; }
        public string _nombre { get; set; }
        public string _apellidos { get; set; }
        public string _telefono { get; set; }
        public int _edad { get; set; }
        public virtual List<Usuario> _usuarios { get; set; }





    }
}
