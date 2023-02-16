using AdresaService.Entities;
using AdresaService.Models;
using AutoMapper;

namespace AdresaService.Profiles
{
    public class DrzavaProfile : Profile
    {
        public DrzavaProfile()
        {
            CreateMap<Drzava, DrzavaDTO>();
            CreateMap<DrzavaCreationDTO, Drzava>();
            CreateMap<Drzava, Drzava>();
            CreateMap<DrzavaDTO, Drzava>();
            CreateMap<Drzava, DrzavaConfirmationDTO>();
            CreateMap<Drzava, DrzavaUpdateDTO>();
            CreateMap<DrzavaUpdateDTO, Drzava>();
        }
    }
}
