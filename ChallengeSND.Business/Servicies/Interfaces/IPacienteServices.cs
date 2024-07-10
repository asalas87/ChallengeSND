using ChallengeSND.Business.DTOS;
using ChallengeSND.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Business.Servicies.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> GetAllPacientes();
        Task<PacienteDto> GetPacienteById(int id);
        Task <PacienteDto>CreatePaciente(PacienteDto pacienteDto);
        Task UpdatePaciente(PacienteDto pacienteDto);
        Task DeletePaciente(int id);
    }
}
