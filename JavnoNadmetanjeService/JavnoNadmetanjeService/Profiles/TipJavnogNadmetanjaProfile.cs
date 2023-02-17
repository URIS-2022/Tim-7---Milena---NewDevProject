using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.Profiles
{
    public class TipJavnogNadmetanjaProfile:Profile
    {
        public TipJavnogNadmetanjaProfile()
        {
            CreateMap<TipJavnogNadmetanja, TipJavnogNadmetanjaDto>();
            CreateMap<TipJavnogNadmetanjaCreationDto, TipJavnogNadmetanja>();
            CreateMap<TipJavnogNadmetanja, TipJavnogNadmetanja>();
            CreateMap<TipJavnogNadmetanjaDto, TipJavnogNadmetanja>();
        }
    }
}
