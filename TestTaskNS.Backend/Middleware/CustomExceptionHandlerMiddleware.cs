using FluentValidation;
using System.Net;
using System.Text.Json;

namespace TestTaskNS.Backend.Middleware;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
        _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        object result = null;

        switch (exception)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = validationException.Errors.Select(e => e.ErrorMessage).ToList();
                break;

            case Exception defaultException:
                code = HttpStatusCode.BadRequest;
                result = defaultException.Message;
                break;

            default:
                code = HttpStatusCode.BadRequest;
                result = "An unknown error occured";
                break;
        }
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (result == null)
        {
            result = exception.Message;
            code = HttpStatusCode.InternalServerError;
        }

        return context.Response.WriteAsync(JsonSerializer.Serialize(new { error = result, errorCode = code }));
    }
}
