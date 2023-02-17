using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class ZalbaProfile:Profile
    {
        public ZalbaProfile()
        {
            CreateMap<Zalba, ZalbaDto>()
                .ForMember(dest => dest.StatusZalbe, opt => opt.MapFrom(src => src.StatusZalbe.NazivStatusaZalbe))
                .ForMember(dest => dest.TipZalbe, opt => opt.MapFrom(src => src.TipZalbe.NazivTipaZalbe))
                .ForMember(dest => dest.RadnjaNaOsnovuZalbe, opt => opt.MapFrom(src => src.RadnjaNaOsnovuZalbe.NazivRadnjeNaOsnovuZalbe));
            CreateMap<ZalbaCreationDto, Zalba>();
            CreateMap<Zalba, ZalbaConfirmationDto>();
            CreateMap<ZalbaDto, Zalba>();
            CreateMap<Zalba, Zalba>();
            CreateMap<Zalba, ZalbaUpdateDto>();
            CreateMap<ZalbaUpdateDto, Zalba>();
            
        }
    }
}
