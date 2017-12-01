using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   [DataContract]
   public class Marca
    {
        [DataMember]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; }

        [DataMember]
        [Required]
        [MaxLength(100)]
        public string Imagen { get; set; }

        [DataMember]
        public ICollection<Producto> Producto { get; set; }

    }
}
