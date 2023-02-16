using KupacServis.Models;
using KupacServis.Entities;
using AutoMapper;

namespace KupacServis.Profiles
{
    public class PrioritetMapper: Profile
    {
        public PrioritetMapper()
        {
            CreateMap<Prioritet, PrioritetDto>();
            CreateMap<PrioritetUpdateDto, Prioritet>();
            CreateMap<PrioritetCreationDto, Prioritet>();
            CreateMap<Prioritet, Prioritet>();
        }
    }
}
