using AutoMapper;
using OglasURIS.DTO;
using OglasURIS.Models;

namespace OglasURIS.Profiles
{
    public class SluzbeniListProfile : Profile
    {
        public SluzbeniListProfile()
        {
            CreateMap<SluzbeniList, SluzbeniListDto>();
            CreateMap<SluzbeniListDto, SluzbeniList>();
        }
    }
}
