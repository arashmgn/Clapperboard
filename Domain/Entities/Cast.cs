using IMDB.Domain.Enums;
using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;
public sealed class Cast : Entity, IAggregateRoot
{
    private Cast()
    {

    }

    public Guid MediaId { get; private set; }
    public Guid PersonId { get; private set; }
    public CastRole Role { get; private set; }
    public Person? Person { get; private set; }

    public static Cast Create(Guid mediaId, Guid personId, CastRole role)
    {
        var cast = new Cast();
        cast.Apply(mediaId, personId, role);
        return cast;
    }

    public void Update(Guid mediaId, Guid personId, CastRole role)
    {
        Apply(mediaId, personId, role);
    }

    private void Apply(Guid mediaId, Guid personId, CastRole role)
    {
        if (mediaId == Guid.Empty || personId == Guid.Empty || !Enum.IsDefined(role))
            throw new DomainException("Invalid input");
        if (PersonId != personId)
            Person = null;
        MediaId = mediaId;
        PersonId = personId;
        Role = role;
    }
}
