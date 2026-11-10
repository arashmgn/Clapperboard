using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesList;
public class GetSeriesListQueryHandler : IRequestHandler<GetSeriesListQuery, List<SeriesEntity>>
{
}
