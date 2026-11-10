using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastList;
public class GetCastListQueryHandler : IRequestHandler<GetCastListQuery, List<CastEntity>>
{
}
