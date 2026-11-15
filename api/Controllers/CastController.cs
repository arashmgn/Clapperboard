using api.Models;
using IMDB.Application.Common;
using IMDB.Application.Dtos;
using IMDB.Application.Features.Cast.Commands.CreateCast;
using IMDB.Application.Features.Cast.Commands.DeleteCast;
using IMDB.Application.Features.Cast.Commands.UpdateCast;
using IMDB.Application.Features.Cast.Queries.GetCastById;
using IMDB.Application.Features.Cast.Queries.GetCastPaginated;
using IMDB.Application.Features.Cast.Queries.GetMediaCast;
using IMDB.Application.Features.Cast.Queries.GetMediaCastPaginated;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class CastController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        (page, pageSize) = Normalize(page, pageSize);
        var (items, totalCount) = await Mediator.Send(new GetCastPaginatedQuery(page, pageSize), ct);
        return Ok(new PagedResponse<CastDto>(items, totalCount, page, pageSize));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var cast = await Mediator.Send(new GetCastByIdQuery(id), ct);
        return cast is null ? NotFound() : Ok(cast);
    }

    [HttpGet("media/{mediaId:guid}")]
    public async Task<IActionResult> GetByMedia(Guid mediaId, CancellationToken ct)
        => Ok(await Mediator.Send(new GetMediaCastQuery(mediaId), ct));

    [HttpGet("media/{mediaId:guid}/paged")]
    public async Task<IActionResult> GetByMediaPaged(Guid mediaId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        (page, pageSize) = Normalize(page, pageSize);
        var (items, totalCount) = await Mediator.Send(new GetMediaCastPaginatedQuery(mediaId, page, pageSize), ct);
        return Ok(new PagedResponse<CastDto>(items, totalCount, page, pageSize));
    }

    [HttpPost("media/{mediaId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create(Guid mediaId, [FromBody] CastRequestDto dto, CancellationToken ct)
    {
        var id = await Mediator.Send(new CreateCastCommand(mediaId, dto.PersonId, dto.Role), ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}/media/{mediaId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Update(Guid id, Guid mediaId, [FromBody] CastRequestDto dto, CancellationToken ct)
    {
        await Mediator.Send(new UpdateCastCommand(id, mediaId, dto.PersonId, dto.Role), ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await Mediator.Send(new DeleteCastCommand(id), ct);
        return NoContent();
    }
}
