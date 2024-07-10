using AutoMapper;
using ChallengeSND.Data.Models;
using ChallengeSND.Business.DTOS;

namespace ChallengeSND.Business.MappingProfiles
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<Medico, MedicoDto>();
        }
    }
}
