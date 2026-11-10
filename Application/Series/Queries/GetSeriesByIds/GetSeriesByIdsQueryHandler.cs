using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesByIds;
public class GetSeriesByIdsQueryHandler : IRequestHandler<GetSeriesByIdsQuery, List<SeriesEntity>>
{
}
