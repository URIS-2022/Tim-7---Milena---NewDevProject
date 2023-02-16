using AutoMapper;
using KupacServis.Entities;
using KupacServis.Models;

namespace KupacServis.Profiles
{
    public class OvlascenoLiceMapper:Profile
    {
        public OvlascenoLiceMapper()
        {
            CreateMap<OvlascenoLice, OvlascenoLiceDto>();
            CreateMap<OvlascenoLiceUpdateDto, OvlascenoLice>();
            CreateMap<OvlascenoLiceCreationDto, OvlascenoLice>();
            CreateMap<OvlascenoLice, OvlascenoLice>();
            CreateMap<OvlascenoLice, OvlascenoLiceInfoDto>();
            CreateMap<OvlascenoLiceInfoDto, OvlascenoLice>();
            CreateMap<OvlascenoLice, OvlascenoLiceUpdateDto>();
        }
    }
}
