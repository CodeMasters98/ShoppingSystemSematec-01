using Microsoft.AspNetCore.Builder;

namespace ShoppingSystemSematec.Api.Middlewares;

public class LogUrlMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;

    public LogUrlMiddleware(ILogger logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Called!!!");
        await _next(context);
    }
}

public static class LogUrlExtention
{
    public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LogUrlMiddleware>();
    }
}
