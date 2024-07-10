using ChallengeSND.Business.DTOS;
using ChallengeSND.Data.Models;

namespace ChallengeSND.Business.Servicies.Interfaces
{
    public interface IMedicoService
    {
        Task<IEnumerable<MedicoDto>> GetAllMedicos();
        Task<MedicoDto> GetMedicoById(int id);
        Task<MedicoDto> CreateMedico(MedicoDto medicoDto);
        Task UpdateMedico(MedicoDto medicoDto);
        Task DeleteMedico(int id);
    }
}
