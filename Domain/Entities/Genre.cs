using IMDB.Domain.Common;
using System.Reflection;

namespace IMDB.Domain.Entities;
public class Genre : IAggregateRoot
{
    private Genre()
    {
        Title = null;
    }
    public string Title { get; set; }

    public static Create(string title)
    {
        return new Genre { Title = ValidateTitle(title) };
    }

    public void Rename(string title)
    {
        Title = ValidateTitle(title);
    }

    private static string ValidateTitle(string title)
    {
        var value = Guard.NotEmpty(title, "Genre title", 50);

        if (value.Length < 2)
        {
            throw new DomainException("Genre title must be at least 2 characters")
        }
        return value;
    }
}
