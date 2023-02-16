using AutoMapper;
using KupacServis.Entities;
using KupacServis.Models;

namespace KupacServis.Profiles
{
    public class FizickoLiceMapper:Profile
    {
        public FizickoLiceMapper()
        {
            CreateMap<FizickoLice, FizickoLiceDto>();
            CreateMap<FizickoLiceUpdateDto, FizickoLice>();
            CreateMap<FizickoLiceCreationDto, FizickoLice>();
            CreateMap<FizickoLice, FizickoLice>();

        }
    }
}
