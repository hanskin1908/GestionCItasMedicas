using Personas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Infrastructure.Data
{
    public class PersonasDbContext : DbContext
    {
        public PersonasDbContext() : base("name=PersonasConnection")
        {
            Database.SetInitializer<PersonasDbContext>(null);
        }

        public DbSet<Persona> Personas { get; set; }
        //public DbSet<Medico> Medicos { get; set; }
        //public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Persona>()
                .Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Persona>()
                .Property(p => p.TipoDocumento)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Persona>()
                .Property(p => p.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Persona>()
                .Property(p => p.TipoPersona)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Persona>()
                .Property(p => p.Especialidad)
                .HasMaxLength(100);
        }
    }
}
