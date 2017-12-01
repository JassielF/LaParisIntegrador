using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Nucleo.WcfLaParis
{

   public class DetalleServicio
    {

        public int Id { get; set; }

        
        public string Descripcion { get; set; }

        
        public decimal Promocion { get; set; }

        
        public string Mensaje { get; set; }


        public DateTime HoraInicio { get; set; }
        

        public DateTime HoraTermino { get; set; }

     
        public DateTime FechaInicio { get; set; }

 
        public decimal Precio { get; set; }

   
        public ICollection<Servicio> Servicio { get; set; }


    }
}
