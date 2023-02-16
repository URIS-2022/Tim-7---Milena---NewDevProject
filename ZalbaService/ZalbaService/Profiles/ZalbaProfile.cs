using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class ZalbaProfile:Profile
    {
        public ZalbaProfile()
        {
            CreateMap<Zalba, ZalbaDTO>()
                .ForMember(dest => dest.StatusZalbe, opt => opt.MapFrom(src => src.StatusZalbe.NazivStatusaZalbe))
                .ForMember(dest => dest.TipZalbe, opt => opt.MapFrom(src => src.TipZalbe.NazivTipaZalbe))
                .ForMember(dest => dest.RadnjaNaOsnovuZalbe, opt => opt.MapFrom(src => src.RadnjaNaOsnovuZalbe.NazivRadnjeNaOsnovuZalbe));
            CreateMap<ZalbaCreationDTO, Zalba>();
            CreateMap<Zalba, ZalbaConfirmationDTO>();
            CreateMap<ZalbaDTO, Zalba>();
            CreateMap<Zalba, Zalba>();
            CreateMap<Zalba, ZalbaUpdateDTO>();
            CreateMap<ZalbaUpdateDTO, Zalba>();
            
        }
    }
}
