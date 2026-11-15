using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Filters;

public sealed class ApiResponseFilter : IAsyncResultFilter
{
    public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult { Value: not null } result
            && (result.StatusCode is null or (>= 200 and < 300)))
        {
            result.Value = new ApiResponse(true, result.Value);
        }

        return next();
    }
}
