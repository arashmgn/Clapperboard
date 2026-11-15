using api.Models;
using IMDB.Application.Common;
using IMDB.Application.Dtos;
using IMDB.Application.Features.Genres.Commands.CreateGenre;
using IMDB.Application.Features.Genres.Commands.DeleteGenre;
using IMDB.Application.Features.Genres.Commands.UpdateGenre;
using IMDB.Application.Features.Genres.Queries.GetGenreById;
using IMDB.Application.Features.Genres.Queries.GetGenres;
using IMDB.Application.Features.Genres.Queries.GetGenresPaginated;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class GenreController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => Ok(await Mediator.Send(new GetGenresQuery(), ct));

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        (page, pageSize) = Normalize(page, pageSize);
        var (items, totalCount) = await Mediator.Send(new GetGenresPaginatedQuery(page, pageSize), ct);
        return Ok(new PagedResponse<GenreDto>(items, totalCount, page, pageSize));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var genre = await Mediator.Send(new GetGenreByIdQuery(id), ct);
        return genre is null ? NotFound() : Ok(genre);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create([FromBody] GenreRequestDto dto, CancellationToken ct)
    {
        var id = await Mediator.Send(new CreateGenreCommand(dto.Title), ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Update(Guid id, [FromBody] GenreRequestDto dto, CancellationToken ct)
    {
        await Mediator.Send(new UpdateGenreCommand(id, dto.Title), ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await Mediator.Send(new DeleteGenreCommand(id), ct);
        return NoContent();
    }
}
