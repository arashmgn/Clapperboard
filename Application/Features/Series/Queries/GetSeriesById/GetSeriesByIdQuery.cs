namespace IMDB.Application.Features.Series.Queries.GetSeriesById;
public record GetSeriesByIdQuery(Guid Id) : IRequest<SeriesDto?>;
