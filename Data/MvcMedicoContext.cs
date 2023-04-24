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

        
    }
}
