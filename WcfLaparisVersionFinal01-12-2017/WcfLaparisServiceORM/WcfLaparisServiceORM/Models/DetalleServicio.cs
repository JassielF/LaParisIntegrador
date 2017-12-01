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
    public class DetalleServicio
    {
        [DataMember]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Descripcion { get; set; }

        [DataMember]
        [Required]
        [RegularExpression(@"^(0|-?\d{0,18}(\.\d{0,2})?)$")]
        public decimal Promocion { get; set; }

        [DataMember]
        [Required]
        public string Mensaje { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraInicio { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraTermino { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime FechaInicio { get; set; }

        [DataMember]
        [Required]
        [RegularExpression(@"^(0|-?\d{0,18}(\.\d{0,2})?)$")]
        public decimal Total { get; set; }

        [DataMember]
        public ICollection<Servicio> Servicio { get; set; }

      

        
    }
}
