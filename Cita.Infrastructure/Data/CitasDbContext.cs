
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;

using System.Text;
using System.Threading.Tasks;
using Citas.Domain;
using Citas.Domain.Entities;

namespace Citas.Infrastructure.Data
{
    public class CitasDbContext : DbContext
    {
        public CitasDbContext() : base("CitasConnection") { }

        public DbSet<Citas.Domain.Entities.Cita> Citas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas.Domain.Entities.Cita>()
                .Property(c => c.Lugar)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Citas.Domain.Entities.Cita>()
                .Property(c => c.Estado)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
