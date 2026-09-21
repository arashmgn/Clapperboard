namespace IMDB.Domain.ValueObjects;

public record MediaInfo
{
    public string ImdbId { get; }
    public string Title { get; }
    public string Description { get; }
    public string PosterUrl { get; }
    public DateTime ReleaseDate { get; }

    public MediaInfo(string imdbId, string title, string description, string posterUrl, DateTime releaseDate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));

        ImdbId = imdbId;
        Title = title;
        Description = description;
        PosterUrl = posterUrl;
        ReleaseDate = releaseDate;
    }
}
