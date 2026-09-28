using MediatR;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastById;

public record GetCastByIdQuery(int Id) : IRequest<CastEntity?>;
