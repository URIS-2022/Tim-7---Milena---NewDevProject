using AutoMapper;
using KomisijaURIS.Entites;
using KomisijaURIS.Models;

namespace KomisijaURIS.Profiles
{
    public class KomisijaProfile : Profile
    {
        public KomisijaProfile()
        {
            CreateMap<Komisija, KomisijaDto>();
            CreateMap<KomisijaDto, Komisija>();
            CreateMap<Komisija, KomisijaGetDto>();
            CreateMap<KomisijaGetDto, Komisija>();
        }
    }
}
