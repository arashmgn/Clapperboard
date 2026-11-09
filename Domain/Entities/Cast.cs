using api.Enums;
using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;
public class Cast : IAggregateRoot
{
    private Cast()
    {

    }

    public Guid MediaId { get; private set; }
    public Guid PersonalId { get; private set; }
    public CastRole Role { get; private set; }
    public Person? Person { get; private set; }

    public static Cast Create(Guid mediaId, Guid persionId, CastRole role)
    {
        var cast = new Cast();
        cast.Apply(mediaId, personId, role);
        return cast
    }

    public void Update(Guid mediaId, Guid personId, CastRole role)
    {
        Apply(mediaId, personId, role);
    }

    private void Apply(Guid mediaId, Guid personId, CastRole role)
    {
        if (mediaId == Guid.Empty || personId == Guid.Empty || !Enum.IsDefined(role))
            throw new DomainException("Invalid input");
        if (PersonalId != personId)
            Person = null;
        MediaId = mediaId;
        PersonalId = personId;
        Role = role;
    }
}
