using AutoMapper;
using ChallengeSND.Business.DTOS;
using ChallengeSND.Business.Servicies.Interfaces;
using ChallengeSND.Data.Models;
using ChallengeSND.Data.Repositories;
using ChallengeSND.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeSND.Business.Servicies
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public MedicoService(IMedicoRepository medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicoDto>> GetAllMedicos()
        {
            var medicos = await _medicoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicoDto>>(medicos);
        }

        public async Task<MedicoDto> GetMedicoById(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);
            return _mapper.Map<MedicoDto>(medico);
        }

        public async Task<MedicoDto> CreateMedico(MedicoDto medicoDto)
        {
            // Convierte MedicoDto a Medico
            var medico = new Medico
            {
                Nombre = medicoDto.Nombre,
                Apellido = medicoDto.Apellido,
                FechaNacimiento = medicoDto.FechaNacimiento,
                Especialidad = medicoDto.Especialidad,
                ConTurnosDisponibles = medicoDto.ConTurnosDisponibles
            };

            
            await _medicoRepository.AddAsync(medico);
            await _medicoRepository.SaveChangesAsync();

            // Convierte el Medico guardado de vuelta a MedicoDto
            var medicoDtoResult = new MedicoDto
            {
                Id = medico.Id,  
                Nombre = medico.Nombre,
                Apellido = medico.Apellido,
                FechaNacimiento = (DateTime)medico.FechaNacimiento,
                Especialidad = medico.Especialidad,
                ConTurnosDisponibles = medico.ConTurnosDisponibles
            };

            return medicoDtoResult;
        }

        public async Task UpdateMedico(MedicoDto medicoDto)
        {
            var medico = _mapper.Map<Medico>(medicoDto);
            await _medicoRepository.UpdateAsync(medico);
        }

        public async Task DeleteMedico(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);
            if (medico != null)
            {
                await _medicoRepository.DeleteAsync(id);
            }
        }

    }
}
