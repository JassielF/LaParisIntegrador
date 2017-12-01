using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.LaparisORM.Models
{
    class Producto
    {
        [Key]
        public int _id { get; set; }
        public string _nombre { get; set; }
        public int _cantidad { get; set; }
        public string _codigo { get; set; }
        public string _detalle { get; set; }
        public string _imagen { get; set; }
        public int _promocion { get; set; }
        public virtual List<Marca> _marcas { get; set; }
        public virtual List<Sucursal> _sucursales { get; set; }
        public virtual List<Categoria> _categorias { get; set; }

        public int _agendaId { get; set; }
        public virtual Agenda _agenda { get; set; }


    }
}
