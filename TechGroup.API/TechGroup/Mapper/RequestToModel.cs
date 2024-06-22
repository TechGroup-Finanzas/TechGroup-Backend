using TechGroup.API.TechGroup.Products.Request;
using TechGroup.API.TechGroup.Users.Request;
using TechGroup.API.TechGroup.Customers.Request;
using TechGroup.Infrastructure.TechGroup.Products.Models;
using TechGroup.Infrastructure.TechGroup.Users.Models;
using TechGroup.Infrastructure.TechGroup.Customers.Models;

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
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));
            
            CreateMap<CustRequest, Customer>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest=>dest.phone,opt=>opt.MapFrom(src=>src.phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.rate_type, opt => opt.MapFrom(src => src.rate_type))
                .ForMember(dest => dest.capitalization, opt => opt.MapFrom(src => src.capitalization))
                .ForMember(dest => dest.rate, opt => opt.MapFrom(src => src.rate))
                .ForMember(dest => dest.period, opt => opt.MapFrom(src => src.period))
                .ForMember(dest => dest.limit, opt => opt.MapFrom(src => src.limit))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
                .ForMember(dest => dest.payment_date, opt => opt.MapFrom(src => src.payment_date));
        }
    }   
    
}
