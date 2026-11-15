using FluentAssertions;
using IMDB.Domain.Common;
using IMDB.Domain.Entities;
using IMDB.Domain.ValueObjects;

namespace Tests.Domain;

public class SeriesTests
{
    private static Series NewSeries() => Series.Create(
        "tt0001", "Severance", new DateTime(2022, 2, 18), "Work and life.", "https://example.com/p.jpg", 8.7,
        [Genre.Create("Drama")]);

    private static Season AddSeason(Series series, int number) => series.AddSeason(
        $"ts{number}", $"Season {number}", new DateTime(2022, 2, 18), "Season.", "https://example.com/s.jpg", 8.0, number, 9);

    [Fact]
    public void A_series_needs_at_least_one_genre()
    {
        var act = () => Series.Create("tt1", "T", DateTime.UtcNow, "d", "https://example.com/p.jpg", 5, []);

        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Season_numbers_are_unique_inside_a_series()
    {
        var series = NewSeries();
        AddSeason(series, 1);

        var act = () => AddSeason(series, 1);

        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Episode_numbers_are_unique_inside_a_season()
    {
        var series = NewSeries();
        var season = AddSeason(series, 1);
        series.AddEpisode(season.Id, "te1", "Pilot", DateTime.UtcNow, "d", "https://example.com/e.jpg", 7, 1, 55);

        var act = () => series.AddEpisode(season.Id, "te2", "Again", DateTime.UtcNow, "d", "https://example.com/e.jpg", 7, 1, 55);

        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Rating_and_imdb_id_are_validated()
    {
        var rating = () => Rating.From(11);
        var imdbId = () => ImdbId.From(" ");

        rating.Should().Throw<DomainException>();
        imdbId.Should().Throw<DomainException>();
    }
}
