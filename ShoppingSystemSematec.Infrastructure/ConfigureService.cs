using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingSystemSematec.Application.Contracts;
using ShoppingSystemSematec.Infrastructure.Context;
using ShoppingSystemSematec.Infrastructure.Persistence.Repositories;

namespace ShoppingSystemSematec.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services,string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
