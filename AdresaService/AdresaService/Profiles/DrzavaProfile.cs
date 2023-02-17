using AdresaService.Entities;
using AdresaService.Models;
using AutoMapper;

namespace AdresaService.Profiles
{
    public class DrzavaProfile : Profile
    {
        public DrzavaProfile()
        {
            CreateMap<Drzava, DrzavaDto>();
            CreateMap<DrzavaCreationDto, Drzava>();
            CreateMap<Drzava, Drzava>();
            CreateMap<DrzavaDto, Drzava>();
            CreateMap<Drzava, DrzavaConfirmationDto>();
            CreateMap<Drzava, DrzavaUpdateDto>();
            CreateMap<DrzavaUpdateDto, Drzava>();
        }
    }
}
