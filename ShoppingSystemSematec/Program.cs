using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using ShoppingSystemSematec.Api;
using ShoppingSystemSematec.Api.Middlewares;
using ShoppingSystemSematec.Application;
using ShoppingSystemSematec.Infrastructure;
using ShoppingSystemSematec.Infrastructure.Identity;

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
string userDatabaseConnectionString = builder.Configuration.GetConnectionString("UserDatabase");

//IOptions
//IOptionsSnapshot
//IOptionsMonitor

builder.Services
        .RegisterApplicationServices()
        .RegisterIdentityInfrastructureServices(builder.Configuration,userDatabaseConnectionString)
        .RegisterInfrastructureServices(connectionString)
        .RegisterPresentationServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apiVersioningBuilder = builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});

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
