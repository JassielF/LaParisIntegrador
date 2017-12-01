using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.WcfLaParis
{

   public class Agenda
    {

        public int Id { get; set; }

      
        public DateTime FechaRegistro { get; set; }

        public int idServicio { get; set; }
     
        public Servicio Servicio { get; set;}

        public int idPersona { get; set; }
    
        public Persona Persona { get; set; }

    }
}
