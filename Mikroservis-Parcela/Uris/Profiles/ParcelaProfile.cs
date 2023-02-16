using AutoMapper;
using Uris.DTO;
using Uris.Models;

namespace Uris.Profiles
{
    public class ParcelaProfile : Profile
    {
        public ParcelaProfile()
        {
            CreateMap<Parcela, ParcelaDTO>();
            CreateMap<ParcelaDTO, Parcela>();
            CreateMap<Parcela, ParcelaInfoDTO>();
            CreateMap<ParcelaCreationDTO, Parcela>();
        }
    }
}
