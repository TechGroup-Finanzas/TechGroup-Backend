using TechGroup.API.TechGroup.Products.Response;
using TechGroup.API.TechGroup.Users.Response;
using TechGroup.API.TechGroup.Customers.Response;
using TechGroup.Infrastructure.TechGroup.Products.Models;
using TechGroup.Infrastructure.TechGroup.Users.Models;
using TechGroup.Infrastructure.TechGroup.Customers.Models;
using TechGroup.API.TechGroup.Payplans.Response;
using TechGroup.Infrastructure.TechGroup.Payplans.Models;
using TechGroup.API.TechGroup.Questions.Response;
using TechGroup.Infrastructure.TechGroup.Questions.Models;
using TechGroup.Infrastructure.TechGroup.Answers.Models;
using TechGroup.API.TechGroup.Answers.Response;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;
using TechGroup.API.TechGroup.Purchases.Response;

namespace TechGroup.API.TechGroup.Mapper
{
    public class ModelToResponse : AutoMapper.Profile
    {
        public ModelToResponse()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.lastname, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.dni, opt => opt.MapFrom(src => src.Dni))
                .ForMember(dest => dest.birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.date_register, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.mora, opt => opt.MapFrom(src => src.Mora));


            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.Amount));

            CreateMap<Customer, CustResponse>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.id_user, opt => opt.MapFrom(src => src.User_id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.lastname, opt => opt.MapFrom(src => src.Lastname))
                .ForMember(dest => dest.dni, opt => opt.MapFrom(src => src.Dni))
                .ForMember(dest => dest.birthdate, opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.rate_type, opt => opt.MapFrom(src => src.Rate_type))
                .ForMember(dest => dest.capitalization, opt => opt.MapFrom(src => src.Capitalization))
                .ForMember(dest => dest.rate, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.period, opt => opt.MapFrom(src => src.Period))
                .ForMember(dest => dest.limit, opt => opt.MapFrom(src => src.Limit))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.payment_date, opt => opt.MapFrom(src => src.Payment_date));

            CreateMap<Payplan, PayplanResponse>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.id_customer, opt => opt.MapFrom(src => src.Id_customer))
                .ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.monthlyrate, opt => opt.MapFrom(src => src.Monthlyrate))
                .ForMember(dest => dest.number_of_payments, opt => opt.MapFrom(src => src.Number_of_payments))
                .ForMember(dest => dest.grace_periods, opt => opt.MapFrom(src => src.Grace_periods))
                .ForMember(dest => dest.grace_type, opt => opt.MapFrom(src => src.Grace_type))
                .ForMember(dest => dest.date_register, opt => opt.MapFrom(src => src.Date_register))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Question, QuestionResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Answer, AnswerResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question));


            CreateMap<Purchase, PurchaseResponse> ()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.id_customer, opt => opt.MapFrom(src => src.Id_customer))
                .ForMember(dest => dest.product_name, opt => opt.MapFrom(src => src.Product_name))
                .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.date_register, opt => opt.MapFrom(src => src.Date_register))
                .ForMember(dest => dest.interest, opt => opt.MapFrom(src => src.Interest))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
