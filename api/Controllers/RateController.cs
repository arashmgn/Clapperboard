using api.Models;
using IMDB.Application.Dtos;
using IMDB.Application.Features.Rates.Commands.CreateRate;
using IMDB.Application.Features.Rates.Commands.DeleteRate;
using IMDB.Application.Features.Rates.Commands.UpdateRate;
using IMDB.Application.Features.Rates.Queries.GetMediaRates;
using IMDB.Application.Features.Rates.Queries.GetRateById;
using IMDB.Application.Features.Rates.Queries.GetRatesPaginated;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class RateController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        (page, pageSize) = Normalize(page, pageSize);
        var (items, totalCount) = await Mediator.Send(new GetRatesPaginatedQuery(page, pageSize), ct);
        return Ok(new PagedResponse<RateDto>(items, totalCount, page, pageSize));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var rate = await Mediator.Send(new GetRateByIdQuery(id), ct);
        return rate is null ? NotFound() : Ok(rate);
    }

    [HttpGet("media/{mediaId:guid}")]
    public async Task<IActionResult> GetByMedia(Guid mediaId, CancellationToken ct)
        => Ok(await Mediator.Send(new GetMediaRatesQuery(mediaId), ct));

    [HttpPost("media/{mediaId:guid}")]
    [Authorize]
    public async Task<IActionResult> Create(Guid mediaId, [FromBody] RateRequestDto dto, CancellationToken ct)
    {
        var id = await Mediator.Send(new CreateRateCommand(mediaId, dto.Score), ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, [FromBody] RateRequestDto dto, CancellationToken ct)
    {
        await Mediator.Send(new UpdateRateCommand(id, dto.Score), ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await Mediator.Send(new DeleteRateCommand(id), ct);
        return NoContent();
    }
}
