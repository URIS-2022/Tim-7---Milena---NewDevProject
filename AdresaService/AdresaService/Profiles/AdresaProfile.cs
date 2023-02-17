using AdresaService.Entities;
using AdresaService.Models;
using AutoMapper;

namespace AdresaService.Profiles
{
    public class AdresaProfile : Profile
    {
        public AdresaProfile()
        {
            CreateMap<Adresa, AdresaDto>();
            CreateMap<AdresaCreationDto, Adresa>();
            CreateMap<Adresa, Adresa>();
            CreateMap<AdresaDto, Adresa>();
            CreateMap<Adresa, AdresaConfirmationDto>();
            CreateMap<Adresa, AdresaUpdateDto>();
            CreateMap<AdresaUpdateDto, Adresa>();
        }
    }
}
