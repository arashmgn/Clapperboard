namespace api.Models;

public sealed record ApiResponse(bool Success, object? Data = null, IReadOnlyList<string>? Errors = null);

public sealed record PagedResponse<T>(IReadOnlyList<T> Items, int TotalCount, int Page, int PageSize);
