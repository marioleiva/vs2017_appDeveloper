using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class EventoDb : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }

        public EventoDb() : base("EventoDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder); 
        }

    }
}
