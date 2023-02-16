using AutoMapper;
using KupacServis.Entities;
using KupacServis.Models;

namespace KupacServis.Profiles
{
    public class KupacMapper:Profile
    {
        public KupacMapper()
        {
            CreateMap<Kupac, KupacDto>().ForMember(dest => dest.OpisPrioriteta, opt => opt.MapFrom(src => src.Prioritet.OpisPrioriteta));
            CreateMap<KupacUpdateDto, Kupac>();
            CreateMap<KupacUpdateDto, KupacConfirmationDto>();
            CreateMap<KupacCreationDto, Kupac>();
            CreateMap<Kupac, Kupac>();
            CreateMap<Kupac, KupacConfirmationDto>();
            CreateMap<KupacConfirmationDto, Kupac>();
            CreateMap<KupacDto, Kupac>();
            CreateMap<Kupac, KupacOvlascenoDto>();
            CreateMap<KupacOvlascenoDto, Kupac>();
            CreateMap<KupacDto, KupacOvlascenoDto>();
            CreateMap<KupacDto, KupacInfoDto>();
            CreateMap<Kupac, KupacInfoDto>();
            CreateMap<Kupac, KupacUpdateDto>();
        }
    }
}
