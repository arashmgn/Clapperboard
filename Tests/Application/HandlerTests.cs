using AutoMapper;
using FluentAssertions;
using IMDB.Application.Common.Exceptions;
using IMDB.Application.Features.Genres.Commands.CreateGenre;
using IMDB.Application.Features.Genres.Commands.UpdateGenre;
using IMDB.Application.Features.Genres.Queries.GetGenres;
using IMDB.Application.Features.Rates.Commands.CreateRate;
using IMDB.Application.Features.Rates.Commands.DeleteRate;
using IMDB.Application.Features.Rates.Commands.UpdateRate;
using IMDB.Application.Mappings;
using IMDB.Domain.Common;
using IMDB.Domain.Entities;
using IMDB.Domain.Enums;
using Microsoft.Extensions.Logging.Abstractions;
using Tests.Helpers;

namespace Tests.Application;

public class HandlerTests
{
    private static IMapper CreateMapper()
        => new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>(), NullLoggerFactory.Instance).CreateMapper();

    [Fact]
    public async Task CreateGenre_rejects_a_duplicate_title()
    {
        await using var context = DbContextHelper.CreateInMemory();
        var handler = new CreateGenreCommandHandler(context);

        await handler.Handle(new CreateGenreCommand("Drama"), default);
        var act = () => handler.Handle(new CreateGenreCommand(" Drama "), default);

        await act.Should().ThrowAsync<DomainException>();
    }

    [Fact]
    public async Task UpdateGenre_cannot_take_another_genres_title()
    {
        await using var context = DbContextHelper.CreateInMemory();
        await new CreateGenreCommandHandler(context).Handle(new CreateGenreCommand("Drama"), default);
        var comedy = await new CreateGenreCommandHandler(context).Handle(new CreateGenreCommand("Comedy"), default);

        var act = () => new UpdateGenreCommandHandler(context).Handle(new UpdateGenreCommand(comedy, "Drama"), default);

        await act.Should().ThrowAsync<DomainException>();
    }

    [Fact]
    public async Task UpdateGenre_reports_a_missing_genre()
    {
        await using var context = DbContextHelper.CreateInMemory();

        var act = () => new UpdateGenreCommandHandler(context).Handle(new UpdateGenreCommand(Guid.NewGuid(), "Drama"), default);

        await act.Should().ThrowAsync<ApplicationsExceptions.NotFoundException>();
    }

    [Fact]
    public async Task GetGenres_returns_dtos_ordered_by_title()
    {
        await using var context = DbContextHelper.CreateInMemory();
        var create = new CreateGenreCommandHandler(context);
        await create.Handle(new CreateGenreCommand("Western"), default);
        await create.Handle(new CreateGenreCommand("Action"), default);

        var genres = await new GetGenresQueryHandler(context, CreateMapper()).Handle(new GetGenresQuery(), default);

        genres.Select(g => g.Title).Should().Equal("Action", "Western");
    }

    [Fact]
    public async Task A_user_can_rate_a_media_only_once()
    {
        await using var context = DbContextHelper.CreateInMemory();
        var movie = Movie.Create("tt1", "Heat", new DateTime(1995, 12, 15), "Crime.", 170, "https://example.com/p.jpg", 8.3, [Genre.Create("Crime")]);
        context.Movies.Add(movie);
        await context.SaveChangesAsync();
        var handler = new CreateRateCommandHandler(context, new FakeCurrentUser("user-1"));

        await handler.Handle(new CreateRateCommand(movie.Id, ScoreEnum.Four), default);
        var act = () => handler.Handle(new CreateRateCommand(movie.Id, ScoreEnum.Five), default);

        await act.Should().ThrowAsync<DomainException>();
    }

    [Fact]
    public async Task Only_the_owner_can_update_or_delete_a_rate()
    {
        await using var context = DbContextHelper.CreateInMemory();
        var rate = Rate.Create(Guid.NewGuid(), "owner", ScoreEnum.Three);
        context.Rates.Add(rate);
        await context.SaveChangesAsync();
        var stranger = new FakeCurrentUser("stranger");

        var update = () => new UpdateRateCommandHandler(context, stranger).Handle(new UpdateRateCommand(rate.Id, ScoreEnum.One), default);
        var delete = () => new DeleteRateCommandHandler(context, stranger).Handle(new DeleteRateCommand(rate.Id), default);

        await update.Should().ThrowAsync<ForbiddenDomainException>();
        await delete.Should().ThrowAsync<ForbiddenDomainException>();
    }

    [Fact]
    public async Task Anonymous_users_cannot_rate()
    {
        await using var context = DbContextHelper.CreateInMemory();
        var handler = new CreateRateCommandHandler(context, new FakeCurrentUser(null));

        var act = () => handler.Handle(new CreateRateCommand(Guid.NewGuid(), ScoreEnum.Four), default);

        await act.Should().ThrowAsync<ApplicationsExceptions.UnauthorizedException>();
    }
}
