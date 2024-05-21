using Microsoft.EntityFrameworkCore;
using RoleplayApp.Infrastructure.Context;
using TechGroup.API.TechGroup.Mapper;
using TechGroup.Domain.TechGroup.Users.Interfaces;
using TechGroup.Domain.TechGroup.Users.Services;
using TechGroup.Infrastructure.TechGroup.Users.Interfaces;
using TechGroup.Infrastructure.TechGroup.Users.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection

builder.Services.AddScoped<IUserInfrastructure, UserInfrastructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();


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