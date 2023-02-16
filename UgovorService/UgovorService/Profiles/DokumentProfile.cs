using AutoMapper;
using UgovorService.Entities;
using UgovorService.Models;

namespace UgovorService.Profiles
{
    public class DokumentProfile : Profile
    {
        public DokumentProfile()
        {
            CreateMap<Dokument, DokumentDTO>();
            CreateMap<DokumentCreationDTO, Dokument>();
            CreateMap<Dokument, Dokument>();
            CreateMap<DokumentDTO, Dokument>();
            CreateMap<Dokument, DokumentConfirmationDTO>();
            CreateMap<Dokument, DokumentUpdateDTO>();
            CreateMap<DokumentUpdateDTO, Dokument>();
        }

    }
}
