using Recetas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.Infrastructure.Data
{
    public class RecetasDbContext : DbContext
    {
        public RecetasDbContext() : base("RecetasConnection") { }

        public DbSet<Receta> Recetas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receta>()
                .Property(r => r.Codigo)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Receta>()
                .Property(r => r.Estado)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
