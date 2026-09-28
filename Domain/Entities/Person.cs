using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;

public class Person : AggregateRoot
{
    private Person() { }

    public string ImdbId { get; private set; } = string.Empty;
    public string FullName { get; private set; } = string.Empty;
    public DateTime BirthDate { get; private set; }
    public string Bio { get; private set; } = string.Empty;
    public string PhotoUrl { get; private set; } = string.Empty;

    public static Person Create(string imdbId, string fullName, DateTime birthDate, string bio, string photoUrl)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name is required.", nameof(fullName));

        return new Person
        {
            ImdbId = imdbId,
            FullName = fullName,
            BirthDate = birthDate,
            Bio = bio,
            PhotoUrl = photoUrl
        };
    }

    public void Update(string fullName, DateTime birthDate, string bio, string photoUrl)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name is required.", nameof(fullName));

        FullName = fullName;
        BirthDate = birthDate;
        Bio = bio;
        PhotoUrl = photoUrl;
    }
}
