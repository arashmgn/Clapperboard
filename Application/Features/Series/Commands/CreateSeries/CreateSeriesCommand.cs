namespace IMDB.Application.Features.Series.Commands.CreateSeries;
public record CreateSeriesCommand(
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    string PosterUrl,
    double Rate,
    IReadOnlyList<Guid> GenreIds) : IRequest<Guid>;
