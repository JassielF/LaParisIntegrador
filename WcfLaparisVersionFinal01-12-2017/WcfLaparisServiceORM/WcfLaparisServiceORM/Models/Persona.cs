using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLaparisServiceORM.EntitiesModelsLP;

namespace Models
{
    [DataContract]
    public class Persona
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [MaxLength(40)]
        public string Nombre { get; set; }

        [DataMember]
        [Required]
        [MaxLength(40)]
        public string Apellidos { get; set; }

        [DataMember]
        [Required]
        [MaxLength(30)]
        public string Telefono { get; set; }

        [DataMember]
        [Required]
        public int Edad { get; set; }

        [DataMember]
        [Required]
        [ForeignKey("Usuario")]
        public int idUsuario { get; set; }
        [DataMember]
        [CascadeDelete]
        public Usuario Usuario { get; set; }

        [DataMember]
        public ICollection<Agenda> Agenda { get; set; }



    }
}
