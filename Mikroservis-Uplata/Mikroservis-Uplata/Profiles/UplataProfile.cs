using AutoMapper;
using Mikroservis_Uplata.DTO;
using Mikroservis_Uplata.Models;

namespace Mikroservis_Uplata.Profiles
{
    public class UplataProfile : Profile
    {
        public UplataProfile()
        {
            CreateMap<Uplata, UplataDto>();
            CreateMap<UplataDto, Uplata>();
            CreateMap<Uplata, UplataInfoDto>();
            CreateMap<UplataCreationDto, Uplata>();
        }
    }
}
