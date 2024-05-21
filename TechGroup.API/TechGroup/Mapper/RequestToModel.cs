using TechGroup.API.TechGroup.Users.Request;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.API.TechGroup.Mapper
{
    public class RequestToModel : AutoMapper.Profile
    {
        public RequestToModel()
        {
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni));
        }
    }   
    
}
