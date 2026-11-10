using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesById;
public class GetSeriesByIdQueryHandler : IRequestHandler<GetSeriesByIdQuery, SeriesEntity?>
{
}
