using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;

public class Episode : BaseEntity
{
    private Episode() { }

    internal Episode(int episodeNumber, string? title, DateTime releaseDate, int? durationMinutes)
    {
        if (episodeNumber <= 0)
            throw new ArgumentException("Episode number must be positive.", nameof(episodeNumber));

        EpisodeNumber = episodeNumber;
        Title = title;
        ReleaseDate = releaseDate;
        DurationMinutes = durationMinutes;
    }

    public int EpisodeNumber { get; private set; }
    public string? Title { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public int? DurationMinutes { get; private set; }
}
