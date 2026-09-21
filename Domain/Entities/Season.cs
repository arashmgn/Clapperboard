using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;

public class Season : BaseEntity
{
    private readonly List<Episode> _episodes = new();

    private Season() { }

    internal Season(int seasonNumber, string? title, DateTime releaseDate)
    {
        if (seasonNumber <= 0)
            throw new ArgumentException("Season number must be positive.", nameof(seasonNumber));

        SeasonNumber = seasonNumber;
        Title = title;
        ReleaseDate = releaseDate;
    }

    public int SeasonNumber { get; private set; }
    public string? Title { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public IReadOnlyCollection<Episode> Episodes => _episodes;

    internal Episode AddEpisode(int episodeNumber, string? title, DateTime releaseDate, int? durationMinutes)
    {
        if (_episodes.Any(e => e.EpisodeNumber == episodeNumber))
            throw new InvalidOperationException($"Episode {episodeNumber} already exists.");

        var episode = new Episode(episodeNumber, title, releaseDate, durationMinutes);
        _episodes.Add(episode);
        return episode;
    }
}
