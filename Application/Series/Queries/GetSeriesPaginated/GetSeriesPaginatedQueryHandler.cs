using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesPaginated;
public class GetSeriesPaginatedQueryHandler : IRequestHandler<GetSeriesPaginatedQuery, (List<SeriesEntity> Items, int TotalCount)>
{
}
