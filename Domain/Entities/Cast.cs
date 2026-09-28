using api.Enums;
using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;

public class Cast : AggregateRoot
{
    private Cast() { }

    public ReviewTargetType TargetType { get; private set; }
    public int TargetId { get; private set; }
    public int PersonId { get; private set; }
    public CastRole Role { get; private set; }

    public static Cast Create(ReviewTargetType targetType, int targetId, int personId, CastRole role)
    {
        return new Cast
        {
            TargetType = targetType,
            TargetId = targetId,
            PersonId = personId,
            Role = role
        };
    }

    public void ChangeRole(CastRole role) => Role = role;
}
