using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
namespace JavnoNadmetanjeService.Profiles
{
    public class StatusJavnogNadmetanjaProfile:Profile
    {
        public StatusJavnogNadmetanjaProfile()
        {
            CreateMap<StatusJavnogNadmetanja, StatusJavnogNadmetanjaDto>();
            CreateMap<StatusJavnogNadmetanjaCreationDto, StatusJavnogNadmetanja>();
            CreateMap<StatusJavnogNadmetanja, StatusJavnogNadmetanja>();
            CreateMap<StatusJavnogNadmetanjaDto, StatusJavnogNadmetanja>();
        }
    }
}
