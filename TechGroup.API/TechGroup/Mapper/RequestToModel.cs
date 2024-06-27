using TechGroup.API.TechGroup.Products.Request;
using TechGroup.API.TechGroup.Users.Request;
using TechGroup.API.TechGroup.Customers.Request;
using TechGroup.Infrastructure.TechGroup.Products.Models;
using TechGroup.Infrastructure.TechGroup.Users.Models;
using TechGroup.Infrastructure.TechGroup.Customers.Models;
using TechGroup.API.TechGroup.Payplans.Request;
using TechGroup.Infrastructure.TechGroup.Payplans.Models;
using TechGroup.API.TechGroup.Answers.Request;
using TechGroup.Infrastructure.TechGroup.Answers.Models;
using TechGroup.API.TechGroup.Questions.Request;
using TechGroup.Infrastructure.TechGroup.Questions.Models;
using TechGroup.API.TechGroup.Purchases.Request;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.API.TechGroup.Mapper
{
    public class RequestToModel : AutoMapper.Profile
    {
        public RequestToModel()
        {
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.password))
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.dni))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.birthday))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.phone))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.photo))
                .ForMember(dest => dest.Mora, opt => opt.MapFrom(src => src.mora));

            CreateMap<ProductRequest, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.amount));
            
            CreateMap<CustRequest, Customer>()
                .ForMember(dest => dest.User_id, opt => opt.MapFrom(src => src.id_user))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.lastname))
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.dni))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.birthdate))
                .ForMember(dest=>dest.Phone,opt=>opt.MapFrom(src=>src.phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.Rate_type, opt => opt.MapFrom(src => src.rate_type))
                .ForMember(dest => dest.Capitalization, opt => opt.MapFrom(src => src.capitalization))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.rate))
                .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.period))
                .ForMember(dest => dest.Limit, opt => opt.MapFrom(src => src.limit))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status))
                .ForMember(dest => dest.Payment_date, opt => opt.MapFrom(src => src.payment_date));

            CreateMap<PayplanRequest, Payplan>()
                .ForMember(dest => dest.Id_customer , opt => opt.MapFrom(src => src.id_customer))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.amount))
                .ForMember(dest => dest.Monthlyrate, opt => opt.MapFrom(src => src.monthlyrate))
                .ForMember(dest => dest.Number_of_payments, opt => opt.MapFrom(src => src.number_of_payments))
                .ForMember(dest => dest.Grace_periods, opt => opt.MapFrom(src => src.grace_periods))
                .ForMember(dest => dest.Grace_type, opt => opt.MapFrom(src => src.grace_type))
                .ForMember(dest => dest.Date_register, opt => opt.MapFrom(src => src.date_register))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status));

            CreateMap<AnswerRequest, Answer>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.QuestionId));

            CreateMap<QuestionRequest, Question>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
     
            CreateMap<PurchaseRequest, Purchase>()
                .ForMember(dest => dest.Id_customer, opt => opt.MapFrom(src => src.id_customer))
                .ForMember(dest => dest.Product_name, opt => opt.MapFrom(src => src.product_name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.amount))
                .ForMember(dest => dest.Date_register, opt => opt.MapFrom(src => src.date_register))
                .ForMember(dest => dest.Interest, opt => opt.MapFrom(src => src.interest))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status));



        }
    }   
    
}
