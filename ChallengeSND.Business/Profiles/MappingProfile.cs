using AutoMapper;
using ChallengeSND.Business.DTOS;
using ChallengeSND.Data.Models;

namespace ChallengeSND.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Medico, MedicoDto>().ReverseMap();

            CreateMap<Paciente, PacienteDto>()
                .ForMember(dest => dest.Clasificacion, opt => opt.MapFrom(src => src.ClasificacionEdad))  
                .ReverseMap()
                .ForMember(dest => dest.ClasificacionEdad, opt => opt.MapFrom(src => src.Clasificacion));  
        }
    }
}
