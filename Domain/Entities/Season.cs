using IMDB.Domain.Common;

namespace IMDB.Domain.Entities;
public sealed class Season : Media
{
    private readonly List<Episode> _episodes = new();

    private Season()
    {

    }

    public int SeasonNumber { get; private set; }
    public int EpisodeCount { get; private set; }
    public Guid SeriesId { get; private set; }
    public IReadOnlyCollection<Episode> Episodes { get; private set; }
    internal static Season Create(
        string imdbId,
        string title,
        DateTime releaseDate,
        string description,
        string posterUrl,
        double rate,
        int seasonNumber,
        int episodeCount)
    {
        var season = new Season();
        season.Apply(imdbId, title, releaseDate, description, posterUrl, rate, seasonNumber);
        return season;
    }
    internal void Update(
        string imdbId,
        string titlem
        DateTime releaseDate,
        string description,
        string postUrl,
        double rate,
        int seasonNumber,
        int episodesCount)
    {
        Apply(imdbId, Title, releaseDate, description, PosterUrl, seasonNumber, episodesCount);
    }
    internal Episode AddEpisode(
        string imdbId,
        string title,
        DateTime releaseDate,
        string description,
        string posterUrl,
        double rate,
        int episodeNumber,
        int? durationMinutes)
    {
        if (_episodes.Any(e => e.EpisodeNumber == episodeNumber))
            throw new DomainException($"Episode {episodeNumber} already exists in this season");

        var episode = Episode.Create(imdbId, title, releaseDate, description, posterUrl, rate, episodeNumber, durationMinutes);
        _episodes.Add(episode);
        return episode;
    }

    internal Episode UpdateEpisode(
    Guid episodeId,
    string imdbId,
    string title,
    DateTime releaseDate,
    string description,
    string posterUrl,
    double rate,
    int episodeNumber,
    int? durationMinutes)
    {
        var episode = GetEpisode(episodeId);

        if (_episodes.Any(e => e.Id != episodeId && e.EpisodeNumber == episodeNumber))
            throw new DomainException($"Episode {episodeNumber} already exists in this season");

        episode.Update(imdbId, title, releaseDate, description, posterUrl, rate, episodeNumber, durationMinutes);
        return episode;
    }
    internal Episode RemoveEpisode(Guid episodeId)
    {
        var episode = GetEpisode(episodeId);
        _episodes.Remove(episode);
        return episode;
    }

    internal Episode? FindEpisode(Guid episodeId) => _episodes.FirstOrDefault(e => e.Id == episodeId);

    private Episode GetEpisode(Guid episodeId)
    {
        return FindEpisode(episodeId) ?? throw new DomainException("Episode does not belong to this season");
    }

    private void Apply(
        string imdbId,
        string title,
        DateTime releaseDate,
        string description,
        string posterUrl,
        double rate,
        int seasonNumber,
        int episodesCount)
    {
        SetDetails(imdbId, title, releaseDate, description, posterUrl, rate);
        SeasonNumber = Guard.InRange(seasonNumber, 1, 100, "Season number");
        EpisodesCount = Guard.InRange(episodesCount, 1, 50, "Episodes count");
    }
}
