using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Movies.Queries.GetMoviesPaginated;

public record GetMoviesPaginatedQuery(int Page, int PageSize) : IRequest<(List<Movie> Items, int TotalCount)>;
