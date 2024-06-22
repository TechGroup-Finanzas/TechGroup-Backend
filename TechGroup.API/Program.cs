using Microsoft.EntityFrameworkCore;
using TechGroup.Infrastructure.Context;
using TechGroup.API.TechGroup.Mapper;
using TechGroup.Domain.TechGroup.Answers.Interfaces;
using TechGroup.Domain.TechGroup.Answers.Services;
using TechGroup.Domain.TechGroup.Products.Interfaces;
using TechGroup.Domain.TechGroup.Products.Services;
using TechGroup.Domain.TechGroup.Questions.Interfaces;
using TechGroup.Domain.TechGroup.Questions.Services;
using TechGroup.Domain.TechGroup.Users.Interfaces;
using TechGroup.Domain.TechGroup.Users.Services;
using TechGroup.Domain.TechGroup.Customers.Interfaces;
using TechGroup.Domain.TechGroup.Customers.Services;
using TechGroup.Infrastructure.TechGroup.Answers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Answers.Services;
using TechGroup.Infrastructure.TechGroup.Products.Interfaces;
using TechGroup.Infrastructure.TechGroup.Products.Services;
using TechGroup.Infrastructure.TechGroup.Questions.Interfaces;
using TechGroup.Infrastructure.TechGroup.Questions.Services;
using TechGroup.Infrastructure.TechGroup.Users.Interfaces;
using TechGroup.Infrastructure.TechGroup.Users.Services;
using TechGroup.Infrastructure.TechGroup.Customers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Customers.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection

builder.Services.AddScoped<IUserInfrastructure, UserInfrastructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

builder.Services.AddScoped<IProductInfrastructure, ProductInfrastructure>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();

builder.Services.AddScoped<IAnswerInfrastructure, AnswerInfrastructure>();
builder.Services.AddScoped<IAnswerDomain, AnswerDomain>();

builder.Services.AddScoped<IQuestionInfrastructure, QuestionInfrastructure>();
builder.Services.AddScoped<IQuestionDomain, QuestionDomain>();

builder.Services.AddScoped<ICustInfrastructure, CustInfrastructure>();
builder.Services.AddScoped<ICustDomain, CustDomain>();

//cors
builder.Services.AddCors(p =>
{
    p.AddPolicy("AllowOrigin",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(RequestToModel)
);

//Connection to MySQL
var connectionString = builder.Configuration.GetConnectionString("TechGroupConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<TechGroupDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

//Authentication - JWT - Not Implemented Yet
/*
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});*/

var app = builder.Build();
app.UseCors("AllowOrigin");

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<TechGroupDbContext>())
{
    context.Database.EnsureCreated();
}

// app.UseMiddleware<JwtMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();