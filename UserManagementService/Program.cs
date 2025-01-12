using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SocialPolitics.UserManagementService;
using SocialPolitics.UserManagementService.Infrastructure.Data.Context;
using SocialPolitics.UserManagementService.Repositories;
using SocialPolitics.UserManagementService.Repositories.Interfaces;
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

builder.Services.Configure<ServiceSettings>(builder.Configuration.GetSection("Database"));

// Register MongoDB client and database
builder.Services.AddSingleton<MongoClient>(s =>
{
    var settings = s.GetRequiredService<IOptions<ServiceSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<IMongoDatabase>(s =>
{
    var settings = s.GetRequiredService<IOptions<ServiceSettings>>().Value;
    var client = s.GetRequiredService<MongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddSingleton<UserManagementContext>();

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
