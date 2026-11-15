using System.Text.Json;
using api.Models;
using IMDB.Application.Common.Exceptions;
using IMDB.Domain.Common;

namespace api.Middleware;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex) when (!context.Response.HasStarted)
        {
            var (status, errors) = Describe(ex);

            if (status == StatusCodes.Status500InternalServerError)
                logger.LogError(ex, "Unhandled exception while processing {Method} {Path}", context.Request.Method, context.Request.Path);

            context.Response.Clear();
            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(new ApiResponse(false, null, errors), JsonOptions));
        }
    }

    private static (int Status, IReadOnlyList<string> Errors) Describe(Exception ex) => ex switch
    {
        ApplicationsExceptions.NotFoundException => (StatusCodes.Status404NotFound, [ex.Message]),
        ApplicationsExceptions.UnauthorizedException => (StatusCodes.Status401Unauthorized, [ex.Message]),
        ApplicationsExceptions.IdentityOperationException identity => (StatusCodes.Status400BadRequest, identity.Errors),
        ForbiddenDomainException => (StatusCodes.Status403Forbidden, [ex.Message]),
        DomainException => (StatusCodes.Status400BadRequest, [ex.Message]),
        _ => (StatusCodes.Status500InternalServerError, ["An unexpected error occurred."])
    };
}
