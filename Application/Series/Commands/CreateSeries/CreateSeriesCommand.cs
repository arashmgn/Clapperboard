using MediatR;

namespace IMDB.Application.Series.Commands.CreateSeries;

public record CreateSeriesCommand(
    string ImdbId,
    string Title,
    string Description,
    string PosterUrl,
    DateTime ReleaseDate,
    List<int> GenreIds) : IRequest<int>;
