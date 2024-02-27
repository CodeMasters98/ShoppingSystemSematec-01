using ShoppingSystemSematec.Api.Contracts;
using ShoppingSystemSematec.Api.Middlewares;
using ShoppingSystemSematec.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//injector
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();

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
