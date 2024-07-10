using AutoMapper;
using ChallengeSND.Data.Models;
using ChallengeSND.Business.DTOS;

namespace ChallengeSND.Business.MappingProfiles
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<Paciente, PacienteDto>();
            CreateMap<PacienteDto, Paciente>();
        }
    }
}
