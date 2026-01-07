using System.Net;
using System.Text.Json;

namespace HomeWorkout.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public ExceptionMiddleware (
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger,
        IWebHostEnvironment env)
    {
    _next = next;
    _logger = logger;
    _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                message = "An unexpected error occurred",
                detail = _env.IsDevelopment() ? ex.Message : null
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }
    }
}