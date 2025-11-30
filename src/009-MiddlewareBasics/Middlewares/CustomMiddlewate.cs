using Microsoft.AspNetCore.Http;

namespace MiddlewareBasics.Middlewares;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers["X-Convention-Middleware"] =
            "Added convention based middleware with extension method";
        await _next(context);
    }
}


public class InterfaceBasedMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
    {
        context.Response.Headers["X-Interface-Middleware"] =
            "Added IMiddleware based middleware with extension method";
        await _next(context);
    }
}


public static class CustomMiddlewareExtension
{
    public static IApplicationBuilder UserCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }

    public static IApplicationBuilder UserCustomInterfaceMiddleware(
        this IApplicationBuilder builder
    )
    {
        return builder.UseMiddleware<InterfaceBasedMiddleware>();
    }
}