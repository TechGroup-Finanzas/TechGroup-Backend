using TechGroup.API.TechGroup.Products.Response;
using TechGroup.API.TechGroup.Purchases.Response;
using TechGroup.API.TechGroup.PurchasesProducts.Response;
using TechGroup.API.TechGroup.Users.Response;
using TechGroup.Infrastructure.TechGroup.Products.Models;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;
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
            
            
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.PurchaseProducts, opt => opt.MapFrom(src => src.PurchaseProducts));

            CreateMap<Purchase, PurchaseResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DateRegister, opt => opt.MapFrom(src => src.DateRegister))
                .ForMember(dest => dest.Interest, opt => opt.MapFrom(src => src.Interest))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.PurchaseProducts, opt => opt.MapFrom(src => src.PurchaseProducts));

            CreateMap<Infrastructure.TechGroup.PurchasesProducts.Models.PurchasesProducts, PurchaseProductResponse>()
                .ForMember(dest => dest.PurchaseId, opt => opt.MapFrom(src => src.PurchaseId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

        }
    }
}
