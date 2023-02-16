using AutoMapper;
using Mikroservis_Uplata.DTO;
using Mikroservis_Uplata.Models;

namespace Mikroservis_Uplata.Profiles
{
    public class KursProfile : Profile
    {
        public KursProfile()
        {
            CreateMap<Kurs, KursDTO>();
            CreateMap<KursDTO, Kurs>();
        }
    }
}
