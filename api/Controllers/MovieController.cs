using api.Models;
using IMDB.Application.Common;
using IMDB.Application.Dtos;
using IMDB.Application.Features.Movies.Commands.CreateMovie;
using IMDB.Application.Features.Movies.Commands.DeleteMovie;
using IMDB.Application.Features.Movies.Commands.UpdateMovie;
using IMDB.Application.Features.Movies.Queries.GetMovieById;
using IMDB.Application.Features.Movies.Queries.GetMovies;
using IMDB.Application.Features.Movies.Queries.GetMoviesPaginated;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class MovieController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => Ok(await Mediator.Send(new GetMoviesQuery(), ct));

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        (page, pageSize) = Normalize(page, pageSize);
        var (items, totalCount) = await Mediator.Send(new GetMoviesPaginatedQuery(page, pageSize), ct);
        return Ok(new PagedResponse<MovieDto>(items, totalCount, page, pageSize));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var movie = await Mediator.Send(new GetMovieByIdQuery(id), ct);
        return movie is null ? NotFound() : Ok(movie);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create([FromBody] MovieRequestDto dto, CancellationToken ct)
    {
        var id = await Mediator.Send(new CreateMovieCommand(
            dto.ImdbId, dto.Title, dto.ReleaseDate, dto.Description, dto.Duration, dto.PosterUrl, dto.Rate, dto.GenreIds), ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Update(Guid id, [FromBody] MovieRequestDto dto, CancellationToken ct)
    {
        await Mediator.Send(new UpdateMovieCommand(
            id, dto.ImdbId, dto.Title, dto.ReleaseDate, dto.Description, dto.Duration, dto.PosterUrl, dto.Rate, dto.GenreIds), ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await Mediator.Send(new DeleteMovieCommand(id), ct);
        return NoContent();
    }
}
