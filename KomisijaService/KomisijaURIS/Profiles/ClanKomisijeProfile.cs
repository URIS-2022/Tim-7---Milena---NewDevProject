using AutoMapper;
using KomisijaURIS.Entites;
using KomisijaURIS.Models;

namespace KomisijaURIS.Profiles
{
    public class ClanKomisijeProfile : Profile
    {
        public ClanKomisijeProfile()
        {
            CreateMap<ClanKomisije, ClanKomisijeDto>();
            CreateMap<ClanKomisijeDto, ClanKomisije>();
        }
    }
}
