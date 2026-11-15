namespace IMDB.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other || other.GetType() != GetType())
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Id != Guid.Empty && Id == other.Id;
    }

    public override int GetHashCode() => Id == Guid.Empty ? base.GetHashCode() : HashCode.Combine(GetType(), Id);
}
