using System.Security.Claims;
using IMDB.Application.Common.Abstractions;

namespace api.Services;

public sealed class CurrentUser(IHttpContextAccessor accessor) : ICurrentUser
{
    public string? UserId
    {
        get
        {
            var user = accessor.HttpContext?.User;

            return user?.FindFirst("nameid")?.Value ?? user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
