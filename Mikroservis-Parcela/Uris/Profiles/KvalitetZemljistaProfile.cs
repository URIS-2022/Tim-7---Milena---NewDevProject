using AutoMapper;
using Uris.DTO;
using Uris.Models;

namespace Uris.Profiles
{
    public class KvalitetZemljistaProfile : Profile
    {
        public KvalitetZemljistaProfile()
        {
            CreateMap<KvalitetZemljista, KvalitetZemljistaDTO>();
            CreateMap<KvalitetZemljistaDTO, KvalitetZemljista>();
        }
    }
}
