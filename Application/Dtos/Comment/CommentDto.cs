namespace IMDB.Application.Dtos;

public sealed record CommentDto(
    Guid Id,
    string Text,
    Guid MediaId,
    string UserId,
    string? UserName,
    DateTime CreatedOn,
    DateTime LastUpdatedOn);
