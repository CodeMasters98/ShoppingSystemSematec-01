using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingSystemSematec.Infrastructure.Context;

namespace ShoppingSystemSematec.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services,string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

        return services;
    }
}
