using AutoMapper;
using KupacServis.Entities;
using KupacServis.Models;

namespace KupacServis.Profiles
{
    public class PravnoLiceMapper:Profile
    {
        public PravnoLiceMapper()
        {
            CreateMap<PravnoLice,PravnoLiceDto>();
            CreateMap<PravnoLiceUpdateDto, PravnoLice>();
            CreateMap<PravnoLiceCreationDto, PravnoLice>();
            CreateMap<PravnoLice, PravnoLice>();

        }
    }
}
