using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
namespace JavnoNadmetanjeService.Profiles
{
    public class StatusJavnogNadmetanjaProfile:Profile
    {
        public StatusJavnogNadmetanjaProfile()
        {
            CreateMap<StatusJavnogNadmetanja, StatusJavnogNadmetanjaDTO>();
            CreateMap<StatusJavnogNadmetanjaCreationDTO, StatusJavnogNadmetanja>();
            CreateMap<StatusJavnogNadmetanja, StatusJavnogNadmetanja>();
            CreateMap<StatusJavnogNadmetanjaDTO, StatusJavnogNadmetanja>();
        }
    }
}
