using static IMDB.Application.Common.Exceptions.ApplicationsExceptions;

namespace IMDB.Application.Common.Abstractions
{
    public interface ICurrentUser
    {
        string? UserId { get; }
    }

    public static class CurrentUserExtensions
    {
        public static string GetRequiredUserId(this ICurrentUser currentUser)
        {
            return currentUser.UserId ?? throw new UnauthorizedException("Invalid credentials");
        }

    }
}