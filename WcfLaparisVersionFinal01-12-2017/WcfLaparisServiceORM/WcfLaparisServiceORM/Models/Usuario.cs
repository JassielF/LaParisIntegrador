using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [MaxLength(100)]
        public string Correo { get; set; }

        [DataMember]
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [DataMember]
        [Required]
        [MaxLength(10)]
        public string TipoUser { get; set; } = "Cliente";

        [DataMember]
        [Required]
        public bool UserActivado { get; set; } = false;

        [DataMember]
        public ICollection<Persona> Persona { get; set; }

       
    }
}
