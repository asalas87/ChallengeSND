using ChallengeSND.data.Repositories;
using ChallengeSND.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeSND.Data.Repositories.Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(int id);
    }
}
