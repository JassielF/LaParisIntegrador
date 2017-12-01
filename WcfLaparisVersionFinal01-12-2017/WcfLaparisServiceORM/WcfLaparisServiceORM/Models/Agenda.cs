using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Agenda
    {
        [DataMember]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        [Required]
        [ForeignKey("Servicio")]
        public int idServicio { get; set; }
        [DataMember]
        public Servicio Servicio { get; set;}

        [DataMember]
        [Required]
        [ForeignKey("Persona")]
        public int idPersona { get; set; }
        [DataMember]
        public Persona Persona { get; set; }

    }
}
