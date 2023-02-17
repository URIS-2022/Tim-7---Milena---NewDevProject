using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.Profiles
{
    public class JavnoNadmetanjeProfile:Profile
    {
        public JavnoNadmetanjeProfile()
        {
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeDto>()
                .ForMember(dest => dest.StatusJavnogNadmetanja, opt => opt.MapFrom(src => src.StatusJavnogNadmetanja.NazivStatusaJavnogNadmetanja))
                .ForMember(dest => dest.TipJavnogNadmetanja, opt => opt.MapFrom(src => src.TipJavnogNadmetanja.NazivTipaJavnogNadmetanja));
            CreateMap<JavnoNadmetanjeCreationDto, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeConfirmationDto>();
            CreateMap<JavnoNadmetanjeDto, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeUpdateDto>();
            CreateMap<JavnoNadmetanjeUpdateDto, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeInfoDto>()
               .ForMember(dest => dest.StatusJavnogNadmetanja, opt => opt.MapFrom(src => src.StatusJavnogNadmetanja.NazivStatusaJavnogNadmetanja))
               .ForMember(dest => dest.TipJavnogNadmetanja, opt => opt.MapFrom(src => src.TipJavnogNadmetanja.NazivTipaJavnogNadmetanja));
        }
    }
}
