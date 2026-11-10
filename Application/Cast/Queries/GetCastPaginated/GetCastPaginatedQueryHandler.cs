using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastPaginated;
public class GetCastPaginatedQueryHandler : IRequestHandler<GetCastPaginatedQuery, (List<CastEntity> Items, int TotalCount)>
{
}
