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
    class Agenda
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        [ForeignKey("Servicio")]
        public int idServicio { get; set; }
        [DataMember]
        public Servicio Servicio { get; set;}

        [DataMember]
        [ForeignKey("Persona")]
        public int idPersona { get; set; }
        [DataMember]
        public Persona Persona { get; set; }

    }
}
