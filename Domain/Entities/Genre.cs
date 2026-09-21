using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;

public class Genre : AggregateRoot
{
    private Genre() { } // for EF

    public string Title { get; private set; } = string.Empty;

    public static Genre Create(string title)
    {
        EnsureValid(title);
        return new Genre { Title = title };
    }

    public void Rename(string title)
    {
        EnsureValid(title);
        Title = title;
    }

    private static void EnsureValid(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));
    }
}
