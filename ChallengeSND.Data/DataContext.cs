using ChallengeSND.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeSND.Data
{


    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medico>()
                .HasOne(m => m.Especialidad);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Medico)
                .WithMany(m => m.Pacientes)
                .HasForeignKey(p => p.MedicoId);
        }
    }

}
