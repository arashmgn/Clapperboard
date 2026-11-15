namespace IMDB.Application.Common.Extensions;
public static class UserNameExtensions
{
    public static async Task<List<CommentDto>> WithUserNamesAsync(
        this IIdentityService identity, List<CommentDto> comments, CancellationToken cancellationToken)
    {
        var names = await identity.GetUserNamesAsync(comments.Select(c => c.UserId), cancellationToken);
        return comments.Select(c => c with { UserName = names.GetValueOrDefault(c.UserId) }).ToList();
    }

    public static async Task<CommentDto?> WithUserNameAsync(
        this IIdentityService identity, CommentDto? comment, CancellationToken cancellationToken)
    {
        if (comment is null)
            return null;

        return comment with { UserName = await identity.GetUserNameAsync(comment.UserId, cancellationToken) };
    }

    public static async Task<List<RateDto>> WithUserNamesAsync(
        this IIdentityService identity, List<RateDto> rates, CancellationToken cancellationToken)
    {
        var names = await identity.GetUserNamesAsync(rates.Select(r => r.UserId), cancellationToken);
        return rates.Select(r => r with { UserName = names.GetValueOrDefault(r.UserId) }).ToList();
    }

    public static async Task<RateDto?> WithUserNameAsync(
        this IIdentityService identity, RateDto? rate, CancellationToken cancellationToken)
    {
        if (rate is null)
            return null;

        return rate with { UserName = await identity.GetUserNameAsync(rate.UserId, cancellationToken) };
    }
}
