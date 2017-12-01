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
   public class Producto
    {
        [DataMember]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [DataMember]
        [Required]
        public int Cantidad { get; set; }

        [DataMember]
        [Required]
        [MaxLength(50)]
        public string Sku { get; set; }

        [DataMember]
        [Required]
        public string Detalle { get; set; }

        [DataMember]
        [Required]
        [MaxLength(50)]
        public string Imagen { get; set; }

        [DataMember]
        [Required]
        [RegularExpression(@"^(0|-?\d{0,18}(\.\d{0,2})?)$")]
        public decimal Promocion { get; set; }

        [DataMember]
        [Required]
        [ForeignKey("Categoria")]
        public int idCategoria { get; set; }
        [DataMember]
        public Categoria Categoria { get; set; }

        [DataMember]
        [Required]
        [ForeignKey("Sucursal")]
        public int idSucursal { get; set; }
        [DataMember]
        public Sucursal Sucursal { get; set; }

        [DataMember]
        [Required]
        [ForeignKey("Marca")]
        public int idMarca { get; set; }
        [DataMember]
        public Marca Marca { get; set; }

        
    }
}
