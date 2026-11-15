using IMDB.Application.Common.Abstractions;

namespace Tests.Helpers;

public sealed class FakeCurrentUser(string? userId) : ICurrentUser
{
    public string? UserId { get; } = userId;
}
