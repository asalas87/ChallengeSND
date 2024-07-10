using ChallengeSND.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeSND.data.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteMedico> PacientesMedicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacienteMedico>()
                .HasKey(pm => new { pm.PacienteId, pm.MedicoId });

            modelBuilder.Entity<PacienteMedico>()
                .HasOne(pm => pm.Paciente)
                .WithMany(p => p.PacientesMedicos)
                .HasForeignKey(pm => pm.PacienteId);

            modelBuilder.Entity<PacienteMedico>()
                .HasOne(pm => pm.Medico)
                .WithMany(m => m.PacientesMedicos)
                .HasForeignKey(pm => pm.MedicoId);
        }
    }
}
