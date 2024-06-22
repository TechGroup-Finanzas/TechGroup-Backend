using TechGroup.API.TechGroup.Products.Request;
using TechGroup.API.TechGroup.Purchases.Request;
using TechGroup.API.TechGroup.Users.Request;
using TechGroup.Infrastructure.TechGroup.Products.Models;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;
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

            CreateMap<ProductRequest, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));

            CreateMap<PurchaseRequest, Purchase>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.DateRegister, opt => opt.MapFrom(src => src.DateRegister))
                .ForMember(dest => dest.Interest, opt => opt.MapFrom(src => src.Interest))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }   
    
}
