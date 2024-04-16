using ShoppingSystemSematec.Api.Shared.Configs;

namespace ShoppingSystemSematec.Api;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<MySettings>(configuration.GetSection("MySettings"));
        return services;
    }
}
