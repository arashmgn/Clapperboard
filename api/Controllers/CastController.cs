using IMDB.Application.Dtos;
using IMDB.Application.Features.Cast.Commands.CreateCast;
using IMDB.Application.Features.Cast.Commands.DeleteCast;
using IMDB.Application.Features.Cast.Commands.UpdateCast;
using IMDB.Application.Features.Cast.Queries.GetCastById;
using IMDB.Application.Features.Cast.Queries.GetCastPaginated;
using api.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CastController : ControllerBase
{
    private readonly IMediator _mediator;

    public CastController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginated([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        var (items, totalCount) = await _mediator.Send(new GetCastPaginatedQuery(page, pageSize), ct);
        return Ok(new { Items = items.Select(c => c.ToDto()), TotalCount = totalCount });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var cast = await _mediator.Send(new GetCastByIdQuery(id), ct);
        return cast is null ? NotFound() : Ok(cast.ToDto());
    }

    [HttpPost("{mediaId:guid}")]
    public async Task<IActionResult> Create(Guid mediaId, [FromBody] CastRequestDto dto, CancellationToken ct)
    {
        var id = await _mediator.Send(new CreateCastCommand(mediaId, dto.PersonId, dto.Role), ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { Id = id });
    }

    [HttpPut("{id:guid}/media/{mediaId:guid}")]
    public async Task<IActionResult> Update(Guid id, Guid mediaId, [FromBody] CastRequestDto dto, CancellationToken ct)
    {
        var updated = await _mediator.Send(new UpdateCastCommand(id, mediaId, dto.PersonId, dto.Role), ct);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var deleted = await _mediator.Send(new DeleteCastCommand(id), ct);
        return deleted ? NoContent() : NotFound();
    }
}
