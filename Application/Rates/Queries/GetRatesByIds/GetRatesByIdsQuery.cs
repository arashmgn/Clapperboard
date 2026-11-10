using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Rates.Queries.GetRatesByIds;
public record GetRatesByIdsQuery : IRequest<List<Rate>>
{
}
