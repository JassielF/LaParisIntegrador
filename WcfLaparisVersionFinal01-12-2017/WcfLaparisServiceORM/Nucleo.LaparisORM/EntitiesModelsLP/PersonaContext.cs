using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleo.LaparisORM.Models;
namespace Nucleo.LaparisORM.EntitiesModelsLP
{
    class PersonaContext: DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
