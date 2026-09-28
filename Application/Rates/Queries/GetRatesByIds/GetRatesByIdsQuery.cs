using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Rates.Queries.GetRatesByIds;

public record GetRatesByIdsQuery(IEnumerable<int> Ids) : IRequest<List<Rate>>;
