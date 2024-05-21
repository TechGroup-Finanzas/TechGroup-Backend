using TechGroup.API.TechGroup.Users.Response;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.API.TechGroup.Mapper
{
    public class ModelToResponse : AutoMapper.Profile
    {
        public ModelToResponse()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
