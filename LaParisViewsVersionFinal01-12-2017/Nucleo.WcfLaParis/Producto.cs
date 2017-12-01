using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.WcfLaParis
{
  public  class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Sku { get; set; }
        public string Detalle { get; set; }
        public string Imagen { get; set; }
        public decimal Promocion { get; set; }
        public Marca Marca { get; set; }
        public Sucursal Sucursal { get; set; }
        public Categoria Categoria { get; set; }
        
    }
}
