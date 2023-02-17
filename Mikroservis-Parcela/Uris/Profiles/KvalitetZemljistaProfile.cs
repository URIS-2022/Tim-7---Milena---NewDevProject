using AutoMapper;
using Uris.DTO;
using Uris.Models;

namespace Uris.Profiles
{
    public class KvalitetZemljistaProfile : Profile
    {
        public KvalitetZemljistaProfile()
        {
            CreateMap<KvalitetZemljista, KvalitetZemljistaDto>();
            CreateMap<KvalitetZemljistaDto, KvalitetZemljista>();
        }
    }
}
