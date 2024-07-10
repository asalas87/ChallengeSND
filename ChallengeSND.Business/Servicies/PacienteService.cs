using AutoMapper;
using ChallengeSND.Business.DTOS;
using ChallengeSND.Business.Servicies.Interfaces;
using ChallengeSND.Data.Models;
using ChallengeSND.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeSND.Business.Servicies
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PacienteDto>> GetAllPacientes()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PacienteDto>>(pacientes);
        }

        public async Task<PacienteDto> GetPacienteById(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            return _mapper.Map<PacienteDto>(paciente);
        }

        public async Task<PacienteDto> CreatePaciente(PacienteDto pacienteDto)
        {
           
            var paciente = _mapper.Map<Paciente>(pacienteDto);

            
            await _pacienteRepository.AddAsync(paciente);
            await _pacienteRepository.SaveChangesAsync();

         
            var pacienteDtoResult = _mapper.Map<PacienteDto>(paciente);

            return pacienteDtoResult;
        }


        public async Task UpdatePaciente(PacienteDto pacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            await _pacienteRepository.UpdateAsync(paciente);
        }

        public async Task DeletePaciente(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente != null)
            {
                await _pacienteRepository.DeleteAsync(id);
            }
        }
    }
}
