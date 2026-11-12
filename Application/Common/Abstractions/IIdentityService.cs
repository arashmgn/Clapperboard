namespace IMDB.Application.Common.Abstractions;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId, CancellationToken cancellationToken = default);

    Task<IReadOnlyDictionary<string, string?>> GetUserNamesAsync(
        IEnumerable<string> userIds,
        CancellationToken cancellationToken = default);

    Task<AuthenticatedUser> RegisterAsync(
        string userName,
        string email,
        string password,
        CancellationToken cancellationToken = default);

    Task<AuthenticatedUser> ValidateCredentialsAsync(
        string userName,
        string password,
        CancellationToken cancellationToken = default);
}