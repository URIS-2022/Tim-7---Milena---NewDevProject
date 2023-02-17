using AutoMapper;
using Uris.DTO;
using Uris.Models;

namespace Uris.Profiles
{
    public class KatastarskaOpstinaProfile : Profile
    {
        public KatastarskaOpstinaProfile()
        {
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaDto>();
            CreateMap<KatastarskaOpstinaDto, KatastarskaOpstina>();
        }
    }
}
