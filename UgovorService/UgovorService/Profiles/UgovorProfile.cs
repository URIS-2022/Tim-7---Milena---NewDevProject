using AutoMapper;
using UgovorService.Entities;
using UgovorService.Models;

namespace UgovorService.Profiles
{
    public class UgovorProfile : Profile
    {
        public UgovorProfile()
        {
            CreateMap<Ugovor, UgovorDto>();
            CreateMap<UgovorCreationDto, Ugovor>();
            CreateMap<Ugovor, Ugovor>();
            CreateMap<UgovorDto, Ugovor>();
            CreateMap<Ugovor, UgovorConfirmationDto>();
            CreateMap<Ugovor, UgovorUpdateDto>();
            CreateMap<UgovorUpdateDto, Ugovor>();
        }

    }
}
