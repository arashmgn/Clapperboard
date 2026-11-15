using FluentAssertions;
using IMDB.Domain.Common;
using IMDB.Domain.Entities;

namespace Tests.Domain;

public class GenreTests
{
    [Fact]
    public void Create_trims_the_title()
    {
        Genre.Create("  Drama  ").Title.Should().Be("Drama");
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("A")]
    public void Create_rejects_blank_or_too_short_titles(string title)
    {
        var act = () => Genre.Create(title);

        act.Should().Throw<DomainException>();
    }
}
