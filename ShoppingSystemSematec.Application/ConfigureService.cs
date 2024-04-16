using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingSystemSematec.Application.Profiles;

namespace ShoppingSystemSematec.Application;

public static class ConfigureService
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductProfile));
        services.AddFluentValidationAutoValidation();
        return services;
    }
}
