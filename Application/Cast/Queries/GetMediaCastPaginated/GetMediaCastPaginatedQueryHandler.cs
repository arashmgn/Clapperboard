using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetMediaCastPaginated;
public class GetMediaCastPaginatedQueryHandler : IRequestHandler<GetMediaCastPaginatedQuery, (List<CastEntity> Items, int TotalCount)>
{
}
