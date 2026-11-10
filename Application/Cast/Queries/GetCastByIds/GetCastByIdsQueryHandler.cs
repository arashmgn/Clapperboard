using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastByIds;
public class GetCastByIdsQueryHandler : IRequestHandler<GetCastByIdsQuery, List<CastEntity>>
{
}
