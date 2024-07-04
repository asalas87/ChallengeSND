using ChallengeSND.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Business.Servicies
{
    public interface IMedicoService
    {
        Task<IEnumerable<Medico>> GetMedicosAsync();
        Task<Medico> GetMedicoByIdAsync(int id);
        Task AddMedicoAsync(Medico medico);
        Task UpdateMedicoAsync(Medico medico);
        Task DeleteMedicoAsync(int id);
        IEnumerable<Medico> GetMedicosByEspecialidad(string especialidad);
    }

}
