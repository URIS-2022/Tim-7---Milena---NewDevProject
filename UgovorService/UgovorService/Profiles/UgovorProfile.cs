using AutoMapper;
using UgovorService.Entities;
using UgovorService.Models;

namespace UgovorService.Profiles
{
    public class UgovorProfile : Profile
    {
        public UgovorProfile()
        {
            CreateMap<Ugovor, UgovorDTO>();
            CreateMap<UgovorCreationDTO, Ugovor>();
            CreateMap<Ugovor, Ugovor>();
            CreateMap<UgovorDTO, Ugovor>();
            CreateMap<Ugovor, UgovorConfirmationDTO>();
            CreateMap<Ugovor, UgovorUpdateDTO>();
            CreateMap<UgovorUpdateDTO, Ugovor>();
        }

    }
}
