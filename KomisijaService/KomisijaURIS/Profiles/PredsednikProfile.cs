using AutoMapper;
using KomisijaURIS.Entites;
using KomisijaURIS.Models;

namespace KomisijaURIS.Profiles
{
    public class PredsednikProfile : Profile
    {
        public PredsednikProfile()
        {
            CreateMap<Predsednik, PredsednikDto>();
            CreateMap<PredsednikDto, Predsednik>();
        }
    }
}
