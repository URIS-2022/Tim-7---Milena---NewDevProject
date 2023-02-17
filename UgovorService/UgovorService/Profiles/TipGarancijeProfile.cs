using AutoMapper;
using UgovorService.Entities;
using UgovorService.Models;

namespace UgovorService.Profiles
{
    public class TipGarancijeProfile : Profile
    {
        public TipGarancijeProfile()
        {
            CreateMap<TipGarancije, TipGarancijeDto>();
            CreateMap<TipGarancijeCreationDto, TipGarancije>();
            CreateMap<TipGarancije, TipGarancije>();
            CreateMap<TipGarancijeDto, TipGarancije>();
            CreateMap<TipGarancije, TipGarancijeConfirmationDto>();
            CreateMap<TipGarancije, TipGarancijeUpdateDto>();
            CreateMap<TipGarancijeUpdateDto, TipGarancije>();
        }
    }
}
