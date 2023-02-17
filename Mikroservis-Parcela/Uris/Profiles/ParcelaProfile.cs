using AutoMapper;
using Uris.DTO;
using Uris.Models;

namespace Uris.Profiles
{
    public class ParcelaProfile : Profile
    {
        public ParcelaProfile()
        {
            CreateMap<Parcela, ParcelaDto>();
            CreateMap<ParcelaDto, Parcela>();
            CreateMap<Parcela, ParcelaInfoDto>();
            CreateMap<ParcelaCreationDto, Parcela>();
        }
    }
}
