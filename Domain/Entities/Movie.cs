using IMDB.Domain.Common;
using IMDB.Domain.ValueObjects;

namespace IMDB.Domain.Entities;

public class Movie : AggregateRoot
{
    private readonly List<Genre> _genres = new();

    private Movie() { } // for EF

    public MediaInfo Info { get; private set; } = null!;
    public int DurationMinutes { get; private set; }
    public double AverageRating { get; private set; }
    public IReadOnlyCollection<Genre> Genres => _genres;

    public static Movie Create(MediaInfo info, int durationMinutes)
    {
        if (durationMinutes <= 0)
            throw new ArgumentException("Duration must be positive.", nameof(durationMinutes));

        return new Movie { Info = info, DurationMinutes = durationMinutes };
    }

    public void Update(MediaInfo info, int durationMinutes)
    {
        if (durationMinutes <= 0)
            throw new ArgumentException("Duration must be positive.", nameof(durationMinutes));

        Info = info;
        DurationMinutes = durationMinutes;
    }

    public void AddGenre(Genre genre)
    {
        if (!_genres.Contains(genre)) _genres.Add(genre);
    }

    public void UpdateAverageRating(double value) => AverageRating = value;
}
