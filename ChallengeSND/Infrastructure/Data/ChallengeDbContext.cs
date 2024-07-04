using ChallengeSND.Domian.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChallengeSND.Infrastructure.Data
{
    public class ChallengeDbContext : DbContext
    {
        public ChallengeDbContext(DbContextOptions<ChallengeDbContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
    }
}
