using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Rates.Queries.GetRatesPaginated;
public record GetRatesPaginatedQuery : IRequest<(List<Rate> Items, int TotalCount)>
{
}
