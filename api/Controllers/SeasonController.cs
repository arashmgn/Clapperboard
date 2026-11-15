using IMDB.Application.Features.Seasons.Queries.GetSeasonById;
using IMDB.Application.Features.Seasons.Queries.GetSeasons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class SeasonController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => Ok(await Mediator.Send(new GetSeasonsQuery(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var season = await Mediator.Send(new GetSeasonByIdQuery(id), ct);
        return season is null ? NotFound() : Ok(season);
    }
}
