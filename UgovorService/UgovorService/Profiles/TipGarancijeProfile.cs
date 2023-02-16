using AutoMapper;
using UgovorService.Entities;
using UgovorService.Models;

namespace UgovorService.Profiles
{
    public class TipGarancijeProfile : Profile
    {
        public TipGarancijeProfile()
        {
            CreateMap<TipGarancije, TipGarancijeDTO>();
            CreateMap<TipGarancijeCreationDTO, TipGarancije>();
            CreateMap<TipGarancije, TipGarancije>();
            CreateMap<TipGarancijeDTO, TipGarancije>();
            CreateMap<TipGarancije, TipGarancijeConfirmationDTO>();
            CreateMap<TipGarancije, TipGarancijeUpdateDTO>();
            CreateMap<TipGarancijeUpdateDTO, TipGarancije>();
        }
    }
}
