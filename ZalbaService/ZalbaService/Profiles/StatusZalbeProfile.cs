using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class StatusZalbeProfile:Profile
    {
        public StatusZalbeProfile()
        {
            CreateMap<StatusZalbe, StatusZalbeDTO>();
            CreateMap<StatusZalbeCreationDTO, StatusZalbe>();
            CreateMap<StatusZalbe, StatusZalbe>();
            CreateMap<StatusZalbeDTO, StatusZalbe>();
        }
    }
}
