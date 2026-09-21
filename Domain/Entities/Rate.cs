using api.Enums;
using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;

public class Rate : AggregateRoot
{
    public const int MinScore = 1;
    public const int MaxScore = 5;

    private Rate() { } // for EF

    public string UserId { get; private set; } = string.Empty;
    public ReviewTargetType TargetType { get; private set; }
    public int TargetId { get; private set; }
    public int Score { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime LastUpdatedOn { get; private set; }

    public static Rate Create(string userId, ReviewTargetType targetType, int targetId, int score)
    {
        EnsureValid(score);

        var now = DateTime.UtcNow;
        return new Rate
        {
            UserId = userId,
            TargetType = targetType,
            TargetId = targetId,
            Score = score,
            CreatedOn = now,
            LastUpdatedOn = now
        };
    }

    public void ChangeScore(int score)
    {
        EnsureValid(score);
        Score = score;
        LastUpdatedOn = DateTime.UtcNow;
    }

    private static void EnsureValid(int score)
    {
        if (score < MinScore || score > MaxScore)
            throw new ArgumentOutOfRangeException(nameof(score), $"Score must be between {MinScore} and {MaxScore}.");
    }
}
