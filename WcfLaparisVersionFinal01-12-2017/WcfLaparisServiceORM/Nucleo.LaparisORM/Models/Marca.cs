using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.LaparisORM.Models
{
    class Marca
    {
        [Key]
        public int _id { get; set; }
        public string _nombre { get; set; }
        public string _imagen { get; set; }

        public int _productoId { get; set; }
        public virtual Producto _producto { get; set; }


    }
}
