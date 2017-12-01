using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.WcfLaParis
{   
   public class Servicio
    {
   
        public int Id { get; set; }

       
        public string Nombre { get; set; }

        
        public decimal Total { get; set; }


        public int idDetalle { get; set; }
       
        public DetalleServicio DetalleServicio { get; set; }

     
        public ICollection<Agenda> Agenda { get; set; }
        


    }
}
