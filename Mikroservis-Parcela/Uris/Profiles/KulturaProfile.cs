using AutoMapper;
using Uris.DTO;
using Uris.Models;

namespace Uris.Profiles
{
    public class KulturaProfile : Profile
    {
        public KulturaProfile()
        {
            CreateMap<Kultura, KulturaDto>();
            CreateMap<KulturaDto, Kultura>();
        }
    }
}
