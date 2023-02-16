using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.Profiles
{
    public class TipJavnogNadmetanjaProfile:Profile
    {
        public TipJavnogNadmetanjaProfile()
        {
            CreateMap<TipJavnogNadmetanja, TipJavnogNadmetanjaDTO>();
            CreateMap<TipJavnogNadmetanjaCreationDTO, TipJavnogNadmetanja>();
            CreateMap<TipJavnogNadmetanja, TipJavnogNadmetanja>();
            CreateMap<TipJavnogNadmetanjaDTO, TipJavnogNadmetanja>();
        }
    }
}
