using Microsoft.EntityFrameworkCore;
using ShoppingSystemSematec.Api;
using ShoppingSystemSematec.Api.Context;
using ShoppingSystemSematec.Api.Middlewares;
using ShoppingSystemSematec.Api.Shared.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

string connectionString = "data source=k2.liara.cloud,33504;Database=shopDb;User ID=sa;Password=hfa4HxYHKfFvrf5aAuj8OKAx;encrypt=false;Trust Server Certificate=true;";
//string connectionString = "data source=k2.liara.cloud,33504;Database=shopDb;User ID=sa;Password=hfa4HxYHKfFvrf5aAuj8OKAx;encrypt=false;Trust Server Certificate=true;";

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

//builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = configurationBuilder.Build();

//IOptions
//IOptionsSnapshot
//IOptionsMonitor

builder.Services.Configure<MySettings>(configuration.GetSection("MySettings"));

builder.Services.RegisterPresentationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
