using AutoMapper;
using OglasURIS.DTO;
using OglasURIS.Models;

namespace OglasURIS.Profiles
{
    public class OglasProfile : Profile
    {
        public OglasProfile()
        {
            CreateMap<Oglas, OglasDto>();
            CreateMap<OglasDto, Oglas>();
            CreateMap<OglasCreationDto, Oglas>();
        }
    }
}
