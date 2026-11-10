using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastById;
public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, CastEntity?>
{
}
