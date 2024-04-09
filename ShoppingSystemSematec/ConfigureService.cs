using FluentValidation.AspNetCore;
using ShoppingSystemSematec.Api.Contracts;
using ShoppingSystemSematec.Api.Profiles;
using ShoppingSystemSematec.Business;

namespace ShoppingSystemSematec.Api;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
    {
        

        services.AddAutoMapper(typeof(ProductProfile));
        services.AddFluentValidationAutoValidation();
        return services;
    }
}
