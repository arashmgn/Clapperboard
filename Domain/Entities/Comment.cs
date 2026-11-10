using IMDB.Domain.Enums;
using IMDB.Domain.Common;
using System.Runtime.Versioning;

namespace IMDB.Domain.Entities;
public sealed class Comment : Entity, IAggregateRoot
{
    private Comment()
    {
        Text = null!;
        UserId = null!;
    }

    public string Text { get; private set; }
    public Guid MediaId { get; private set; }
    public string UserId { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime LastUpdatedOn { get; private set; }

    public static Comment Create(Guid mediaId, string userId, string text)
    {
        if (mediaId == Guid.Empty)
            throw new DomainException("Invalid media ID");
        var now = DateTime.UtcNow;

        return new Comment
        {
            MediaId = mediaId,
            UserId = Guard.NotEmpty(userId, "User", 450),
            Text = Guard.NotEmpty(text, "Comment text", 1000),
            CreatedOn = now,
            LastUpdatedOn = now
        };
    }
    public void Edit(string userId, string text)
    {
        EnsureOwnedBy(userId);

        Text = Guard.NotEmpty(text, "Comment text", 1000);
        LastUpdatedOn = DateTime.UtcNow;
    }

    public void EnsureOwnedBy(string userId)
    {
        if (UserId != userId)
            throw new ForbiddenDomainException("Only the author can modify this comment");
    }
}
