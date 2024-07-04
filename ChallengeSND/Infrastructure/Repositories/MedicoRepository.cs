using ChallengeSND.Domian.Entities;
using ChallengeSND.Domian.Interfaces;
using ChallengeSND.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeSND.Infrastructure.Repositories
{
    public class MedicoRepository : Repository<Medico>
    {
        public MedicoRepository(ChallengeDbContext context) : base(context) { }

        public IEnumerable<Medico> GetMedicosByEspecialidad(string especialidad)
        {
            return _context.Medicos.Where(m => m.Especialidad == especialidad).ToList();
        }
    }

}
