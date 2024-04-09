using Microsoft.Extensions.DependencyInjection;
using ShoppingSystemSematec.Domain.Contracts;
using ShoppingSystemSematec.Infrastructure.Persistence.Repositories;

namespace ShoppingSystemSematec.Application;

public static class ConfigureService
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
