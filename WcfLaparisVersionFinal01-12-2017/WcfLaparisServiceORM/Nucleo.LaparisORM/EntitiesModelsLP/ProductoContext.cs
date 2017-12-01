using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.LaparisORM.EntitiesModelsLP
{
    class ProductoContext: DbContext
    {
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
