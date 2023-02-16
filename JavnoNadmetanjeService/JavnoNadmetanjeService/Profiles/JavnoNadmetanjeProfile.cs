using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.Profiles
{
    public class JavnoNadmetanjeProfile:Profile
    {
        public JavnoNadmetanjeProfile()
        {
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeDTO>()
                .ForMember(dest => dest.StatusJavnogNadmetanja, opt => opt.MapFrom(src => src.StatusJavnogNadmetanja.NazivStatusaJavnogNadmetanja))
                .ForMember(dest => dest.TipJavnogNadmetanja, opt => opt.MapFrom(src => src.TipJavnogNadmetanja.NazivTipaJavnogNadmetanja));
            CreateMap<JavnoNadmetanjeCreationDTO, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeConfirmationDTO>();
            CreateMap<JavnoNadmetanjeDTO, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeUpdateDTO>();
            CreateMap<JavnoNadmetanjeUpdateDTO, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeInfoDTO>()
               .ForMember(dest => dest.StatusJavnogNadmetanja, opt => opt.MapFrom(src => src.StatusJavnogNadmetanja.NazivStatusaJavnogNadmetanja))
               .ForMember(dest => dest.TipJavnogNadmetanja, opt => opt.MapFrom(src => src.TipJavnogNadmetanja.NazivTipaJavnogNadmetanja));
        }
    }
}
