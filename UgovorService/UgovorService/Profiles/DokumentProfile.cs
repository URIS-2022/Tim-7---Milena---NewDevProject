using AutoMapper;
using UgovorService.Entities;
using UgovorService.Models;

namespace UgovorService.Profiles
{
    public class DokumentProfile : Profile
    {
        public DokumentProfile()
        {
            CreateMap<Dokument, DokumentDto>();
            CreateMap<DokumentCreationDto, Dokument>();
            CreateMap<Dokument, Dokument>();
            CreateMap<DokumentDto, Dokument>();
            CreateMap<Dokument, DokumentConfirmationDto>();
            CreateMap<Dokument, DokumentUpdateDto>();
            CreateMap<DokumentUpdateDto, Dokument>();
        }

    }
}
