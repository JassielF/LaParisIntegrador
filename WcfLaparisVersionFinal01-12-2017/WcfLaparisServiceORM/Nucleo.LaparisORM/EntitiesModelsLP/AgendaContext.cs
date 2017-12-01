using Nucleo.LaparisORM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.LaparisORM.EntitiesModelsLP
{
    class AgendaContext: DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }

    }
}
