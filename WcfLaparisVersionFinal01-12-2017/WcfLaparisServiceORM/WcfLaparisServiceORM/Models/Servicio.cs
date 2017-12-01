using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WcfLaparisServiceORM.EntitiesModelsLP;

namespace Models
{   [DataContract]
    public class Servicio
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
        [RegularExpression(@"^(0|-?\d{0,18}(\.\d{0,2})?)$")]
        public decimal Precio { get; set; }

        [DataMember]
        [Required]
        [ForeignKey("DetalleServicio")]
        public int idDetalle { get; set; }
        [DataMember]
        [CascadeDelete]
        public DetalleServicio DetalleServicio { get; set; }

        [DataMember]
        public ICollection<Agenda> Agenda { get; set; }

        
         //public Servicio servicio(string json)
         //   {
         //       JObject jObject = JObject.Parse(json);

         //       JToken jUser = jObject["Servicio"];
         //       Nombre = (string)jUser["Nombre"];
         //       Precio = (decimal)jUser["Precio"];
         //       DetalleServicio = new DetalleServicio();
         //       DetalleServicio.Descripcion = (string)jUser["Descripcion"];
         //       DetalleServicio.FechaInicio = (DateTime)jUser["FechaInicio"];
         //       DetalleServicio.HoraInicio = (DateTime)jUser["HoraInicio"];
         //       DetalleServicio.HoraTermino = (DateTime)jUser["HoraTermino"];
         //       DetalleServicio.Mensaje = (string)jUser["Mensaje"];
         //       DetalleServicio.Promocion = (decimal)jUser["Promocion"];
         //       DetalleServicio.Total = (decimal)jUser["Total"];

         //   return jUser;       
            
         //   }
        
        

    }
}
