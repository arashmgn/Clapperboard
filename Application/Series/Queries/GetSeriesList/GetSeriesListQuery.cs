using MediatR;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesList;

public record GetSeriesListQuery : IRequest<List<SeriesEntity>>;
