using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Nucleo.LaparisORM.Models;

namespace Nucleo.LaparisORM.EntitiesModelsLP
{
    class ServicioContext: DbContext
    {
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<DetalleServicio> Detalles { get; set; }
  
       
        
    }
}
