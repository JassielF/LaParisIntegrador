using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace Nucleo.LaparisORM.Models
{
    [DataContract]
    class DetalleServicio
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public decimal Promocion { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public DateTime HoraInicio { get; set; }

        [DataMember]
        public DateTime HoraTermino { get; set; }

        [DataMember]
        public DateTime FechaInicio { get; set; }

        [DataMember]
        public decimal Precio { get; set; }

        [DataMember]
        public ICollection<Servicio> Servicio { get; set; }


    }
}
