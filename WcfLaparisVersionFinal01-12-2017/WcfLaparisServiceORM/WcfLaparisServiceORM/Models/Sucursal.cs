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
    public class Sucursal
    {
        [DataMember]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [DataMember]
        [Required]
        [MaxLength(30)]
        public string Telefono { get; set; }

        [DataMember]
        [Required]
        [MaxLength(120)]
        public string Direccion { get; set; }

        [DataMember]
        [Required]
        public int CodPostal { get; set; }

        [DataMember]
        [Required]
        [MaxLength(100)]
        public string Correo { get; set; }
        
        [DataMember]
        public ICollection<Producto> Producto { get; set; }

    }
}
