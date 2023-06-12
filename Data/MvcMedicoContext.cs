using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecepcionMedica.Models;

namespace RecepcionMedica.Data
{
    public class MvcMedicoContext : DbContext
    {
        public MvcMedicoContext (DbContextOptions<MvcMedicoContext> options)
            : base(options)
        {
        }

        public DbSet<RecepcionMedica.Models.Medico> Medico { get; set; } = default!;

        public DbSet<RecepcionMedica.Models.Especialidad> Especialidad { get; set; } = default!;

        public DbSet<RecepcionMedica.Models.Paciente> Paciente { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        modelBuilder.Entity<Especialidad>()
        .HasMany(f => f.Medicos)
        .WithOne(f => f.Especialidad )
        .HasForeignKey(f => f.EspecialidadId);

        modelBuilder.Entity<Medico>()
        .HasMany(e => e.Pacientes)
        .WithOne(e => e.Medico)
        .HasForeignKey(e => e.MedicoId);
        }          
    }
}
