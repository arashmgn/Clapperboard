using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Rates.Queries.GetRatesPaginated;

public record GetRatesPaginatedQuery(int Page, int PageSize) : IRequest<(List<Rate> Items, int TotalCount)>;
