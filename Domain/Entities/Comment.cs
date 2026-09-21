using api.Enums;
using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;

public class Comment : AggregateRoot
{
    private Comment() { } // for EF

    public string Text { get; private set; } = string.Empty;
    public string UserId { get; private set; } = string.Empty;
    public ReviewTargetType TargetType { get; private set; }
    public int TargetId { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime LastUpdatedOn { get; private set; }

    public static Comment Create(string text, string userId, ReviewTargetType targetType, int targetId)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text is required.", nameof(text));

        var now = DateTime.UtcNow;
        return new Comment
        {
            Text = text,
            UserId = userId,
            TargetType = targetType,
            TargetId = targetId,
            CreatedOn = now,
            LastUpdatedOn = now
        };
    }

    public void Edit(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text is required.", nameof(text));

        Text = text;
        LastUpdatedOn = DateTime.UtcNow;
    }
}
