using LicitacijaServis.Entities;
using LicitacijaServis.Models;
using AutoMapper;

namespace LicitacijaServis.Profiles
{
    public class LicitacijaMapper : Profile
    {
        public LicitacijaMapper()
        {
            CreateMap<Licitacija, LicitacijaDto>();
            CreateMap<LicitacijaUpdateDto, Licitacija>();
            CreateMap<Licitacija, LicitacijaUpdateDto>();
            CreateMap<LicitacijaCreationDto, Licitacija>();
            CreateMap<Licitacija, LicitacijaConfirmationDto>();
            CreateMap<Licitacija, Licitacija>();
        }

    }
}
