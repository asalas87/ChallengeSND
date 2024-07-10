using ChallengeSND.Data.Models;
using ChallengeSND.Data.Repositories.Interfaces;

namespace ChallengeSND.Data.Repositories
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        Task<IEnumerable<Medico>> GetMedicosByEspecialidadAsync(string especialidad);
    }
}
