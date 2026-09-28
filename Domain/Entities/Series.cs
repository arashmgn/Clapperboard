using IMDB.Domain.Common;
using IMDB.Domain.ValueObjects;

namespace IMDB.Domain.Entities;

public class Series : AggregateRoot
{
    private readonly List<Season> _seasons = new();
    private readonly List<Genre> _genres = new();

    private Series() { }

    public MediaInfo Info { get; private set; } = null!;
    public double AverageRating { get; private set; }
    public IReadOnlyCollection<Season> Seasons => _seasons;
    public IReadOnlyCollection<Genre> Genres => _genres;

    public static Series Create(MediaInfo info) => new Series { Info = info };

    public void Update(MediaInfo info) => Info = info;

    public void AddGenre(Genre genre)
    {
        if (!_genres.Contains(genre)) _genres.Add(genre);
    }

    public Season AddSeason(int seasonNumber, string? title, DateTime releaseDate)
    {
        if (_seasons.Any(s => s.SeasonNumber == seasonNumber))
            throw new InvalidOperationException($"Season {seasonNumber} already exists.");

        var season = new Season(seasonNumber, title, releaseDate);
        _seasons.Add(season);
        return season;
    }

    public Episode AddEpisode(int seasonNumber, int episodeNumber, string? title,
        DateTime releaseDate, int? durationMinutes)
    {
        var season = _seasons.FirstOrDefault(s => s.SeasonNumber == seasonNumber)
            ?? throw new InvalidOperationException($"Season {seasonNumber} not found.");

        return season.AddEpisode(episodeNumber, title, releaseDate, durationMinutes);
    }

    public void UpdateAverageRating(double value) => AverageRating = value;
}
