using Microsoft.EntityFrameworkCore;
using ShoppingSystemSematec.Api;
using ShoppingSystemSematec.Api.Middlewares;
using ShoppingSystemSematec.Application;
using ShoppingSystemSematec.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
        //.AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = configurationBuilder.Build();

//string connectionString = configuration.GetConnectionString("DefaultConnection");
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//IOptions
//IOptionsSnapshot
//IOptionsMonitor

builder.Services
        .RegisterApplicationServices()
        .RegisterInfrastructureServices(connectionString)
        .RegisterPresentationServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseGlobalException();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Write custome Middleware
    
app.UseLogUrl();

app.MapControllers();

app.Run();
