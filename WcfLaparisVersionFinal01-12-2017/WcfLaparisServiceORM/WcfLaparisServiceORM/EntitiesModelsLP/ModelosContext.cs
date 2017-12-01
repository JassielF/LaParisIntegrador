using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WcfLaparisServiceORM.EntitiesModelsLP
{
    public class ModelosContext: DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<DetalleServicio> Detalles { get; set; }

        public ModelosContext(): base("name=ServiciosCS")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add<CascadeDeleteAttributeConvention>();
            
        }

        
        
    }
}