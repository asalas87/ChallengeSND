using ChallengeSND.Domian.Entities;

namespace ChallengeSND.Domian.Interfaces
{
    public interface IMedico
    {
        public interface IMedico : IPersona
        {
            Task<IEnumerable<Medico>> GetMedicosAsync();
            Task<Medico> GetMedicoByIdAsync(int id);
            Task AddMedicoAsync(Medico medico);
            Task UpdateMedicoAsync(Medico medico);
            Task DeleteMedicoAsync(int id);
            IEnumerable<Medico> GetMedicosByEspecialidad(string especialidad);
        }
    }
}
