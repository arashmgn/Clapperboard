using api.Enums;
using MediatR;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetMediaCast;
public record GetMediaCastQuery : IRequest<List<CastEntity>>
{
}
