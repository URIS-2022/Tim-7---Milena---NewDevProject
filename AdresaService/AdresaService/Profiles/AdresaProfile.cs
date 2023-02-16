using AdresaService.Entities;
using AdresaService.Models;
using AutoMapper;

namespace AdresaService.Profiles
{
    public class AdresaProfile : Profile
    {
        public AdresaProfile()
        {
            CreateMap<Adresa, AdresaDTO>();
            CreateMap<AdresaCreationDTO, Adresa>();
            CreateMap<Adresa, Adresa>();
            CreateMap<AdresaDTO, Adresa>();
            CreateMap<Adresa, AdresaConfirmationDTO>();
            CreateMap<Adresa, AdresaUpdateDTO>();
            CreateMap<AdresaUpdateDTO, Adresa>();
        }
    }
}
