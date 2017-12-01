using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.LaparisORM.Models
{   [DataContract]
    class Servicio
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        [ForeignKey("DetalleServicio")]
        public int idDetalle { get; set; }
        [DataMember]
        public DetalleServicio DetalleServicio { get; set; }

        [DataMember]
        public ICollection<Agenda> Agenda { get; set; }
        


    }
}
