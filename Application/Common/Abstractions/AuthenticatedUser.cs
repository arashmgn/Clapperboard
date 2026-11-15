namespace IMDB.Application.Common.Abstractions;

public sealed record AuthenticatedUser(string Id, string UserName, string Email, IReadOnlyList<string> Roles);
