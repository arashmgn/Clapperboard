using api.Models;
using IMDB.Application.Common;
using IMDB.Application.Dtos;
using IMDB.Application.Features.Seasons.Queries.GetSeasons;
using IMDB.Application.Features.Series.Commands.AddEpisode;
using IMDB.Application.Features.Series.Commands.AddSeason;
using IMDB.Application.Features.Series.Commands.CreateSeries;
using IMDB.Application.Features.Series.Commands.DeleteSeries;
using IMDB.Application.Features.Series.Commands.RemoveEpisode;
using IMDB.Application.Features.Series.Commands.RemoveSeason;
using IMDB.Application.Features.Series.Commands.UpdateEpisode;
using IMDB.Application.Features.Series.Commands.UpdateSeason;
using IMDB.Application.Features.Series.Commands.UpdateSeries;
using IMDB.Application.Features.Series.Queries.GetSeriesById;
using IMDB.Application.Features.Series.Queries.GetSeriesList;
using IMDB.Application.Features.Series.Queries.GetSeriesPaginated;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class SeriesController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => Ok(await Mediator.Send(new GetSeriesListQuery(), ct));

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        (page, pageSize) = Normalize(page, pageSize);
        var (items, totalCount) = await Mediator.Send(new GetSeriesPaginatedQuery(page, pageSize), ct);
        return Ok(new PagedResponse<SeriesDto>(items, totalCount, page, pageSize));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var series = await Mediator.Send(new GetSeriesByIdQuery(id), ct);
        return series is null ? NotFound() : Ok(series);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create([FromBody] SeriesRequestDto dto, CancellationToken ct)
    {
        var id = await Mediator.Send(new CreateSeriesCommand(
            dto.ImdbId, dto.Title, dto.ReleaseDate, dto.Description, dto.PosterUrl, dto.Rate, dto.GenreIds), ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Update(Guid id, [FromBody] SeriesRequestDto dto, CancellationToken ct)
    {
        await Mediator.Send(new UpdateSeriesCommand(
            id, dto.ImdbId, dto.Title, dto.ReleaseDate, dto.Description, dto.PosterUrl, dto.Rate, dto.GenreIds), ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await Mediator.Send(new DeleteSeriesCommand(id), ct);
        return NoContent();
    }

    [HttpGet("{seriesId:guid}/seasons")]
    public async Task<IActionResult> GetSeasons(Guid seriesId, CancellationToken ct)
        => Ok(await Mediator.Send(new GetSeasonsQuery(seriesId), ct));

    [HttpPost("{seriesId:guid}/seasons")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> AddSeason(Guid seriesId, [FromBody] SeasonRequestDto dto, CancellationToken ct)
    {
        var id = await Mediator.Send(new AddSeasonCommand(
            seriesId, dto.ImdbId, dto.Title, dto.ReleaseDate, dto.Description, dto.PosterUrl, dto.Rate, dto.SeasonNumber, dto.EpisodesCount), ct);
        return Created($"api/Season/{id}", new { id });
    }

    [HttpPut("{seriesId:guid}/seasons/{seasonId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> UpdateSeason(Guid seriesId, Guid seasonId, [FromBody] SeasonRequestDto dto, CancellationToken ct)
    {
        await Mediator.Send(new UpdateSeasonCommand(
            seriesId, seasonId, dto.ImdbId, dto.Title, dto.ReleaseDate, dto.Description, dto.PosterUrl, dto.Rate, dto.SeasonNumber, dto.EpisodesCount), ct);
        return NoContent();
    }

    [HttpDelete("{seriesId:guid}/seasons/{seasonId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> RemoveSeason(Guid seriesId, Guid seasonId, CancellationToken ct)
    {
        await Mediator.Send(new RemoveSeasonCommand(seriesId, seasonId), ct);
        return NoContent();
    }

    [HttpPost("{seriesId:guid}/seasons/{seasonId:guid}/episodes")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> AddEpisode(Guid seriesId, Guid seasonId, [FromBody] EpisodeRequestDto dto, CancellationToken ct)
    {
        var id = await Mediator.Send(new AddEpisodeCommand(
            seriesId, seasonId, dto.ImdbId, dto.Title, dto.ReleaseDate, dto.Description, dto.PosterUrl, dto.Rate, dto.EpisodeNumber, dto.DurationMinutes), ct);
        return Created($"api/Season/{seasonId}", new { id });
    }

    [HttpPut("{seriesId:guid}/seasons/{seasonId:guid}/episodes/{episodeId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> UpdateEpisode(Guid seriesId, Guid seasonId, Guid episodeId, [FromBody] EpisodeRequestDto dto, CancellationToken ct)
    {
        await Mediator.Send(new UpdateEpisodeCommand(
            seriesId, seasonId, episodeId, dto.ImdbId, dto.Title, dto.ReleaseDate, dto.Description, dto.PosterUrl, dto.Rate, dto.EpisodeNumber, dto.DurationMinutes), ct);
        return NoContent();
    }

    [HttpDelete("{seriesId:guid}/seasons/{seasonId:guid}/episodes/{episodeId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> RemoveEpisode(Guid seriesId, Guid seasonId, Guid episodeId, CancellationToken ct)
    {
        await Mediator.Send(new RemoveEpisodeCommand(seriesId, seasonId, episodeId), ct);
        return NoContent();
    }
}
