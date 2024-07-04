using ChallengeSND.Domian.Entities;
using ChallengeSND.Domian.Interfaces;
using ChallengeSND.Infrastructure.Repositories.Interface;

namespace ChallengeSND.Domian.Services
{
    public class MedicoService : IMedico
    {
        private readonly IRepository<Medico> _medicoRepository;

        public MedicoService(IRepository<Medico> medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await _medicoRepository.GetAllAsync();
        }

        public async Task<Medico> GetMedicoByIdAsync(int id)
        {
            return await _medicoRepository.GetByIdAsync(id);
        }

        public async Task AddMedicoAsync(Medico medico)
        {
            await _medicoRepository.AddAsync(medico);
        }

        public async Task UpdateMedicoAsync(Medico medico)
        {
            await _medicoRepository.UpdateAsync(medico);
        }

        public async Task DeleteMedicoAsync(int id)
        {
            await _medicoRepository.DeleteAsync(id);
        }

        //public IEnumerable<Medico> GetMedicosByEspecialidad(string especialidad)
        //{
        //    return _medicoRepository.;
        //}
    }

}
