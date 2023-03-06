using System.Net;
using Lobby.Logic.Errors;
using System.Text.Json;

namespace Lobby.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception is ApiError apiError)
        {
            context.Response.StatusCode = (int) apiError.Code;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new {error = apiError.Message}));
        }
        else
        {
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new {error = "Internal Server Error"}));
        }
    }
}