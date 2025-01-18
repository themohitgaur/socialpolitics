using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity;
using SocialPolitics.UserManagementService;
using SocialPolitics.UserManagementService.Infrastructure.Data.Context;
using SocialPolitics.UserManagementService.Infrastructure.Data.Models;
using SocialPolitics.UserManagementService.Repositories;
using SocialPolitics.UserManagementService.Repositories.Interfaces;
using SocialPolitics.Core;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddFastEndpoints()
    .SwaggerDocument(opts =>
    {
        opts.DocumentSettings = settigns =>
        {
            settigns.Title = "Social Politics API";
            settigns.Version = "v1";
        };
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

//Custom service registration
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddSingleton<UserManagementContext>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseFastEndpoints();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
