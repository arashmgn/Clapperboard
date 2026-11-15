using FluentAssertions;
using IMDB.Domain.Common;
using IMDB.Domain.Entities;
using IMDB.Domain.Enums;

namespace Tests.Domain;

public class OwnershipTests
{
    private static readonly Guid MediaId = Guid.NewGuid();

    [Fact]
    public void Author_can_edit_a_comment()
    {
        var comment = Comment.Create(MediaId, "user-1", "first");

        comment.Edit("user-1", "second");

        comment.Text.Should().Be("second");
    }

    [Fact]
    public void Other_users_cannot_edit_a_comment()
    {
        var comment = Comment.Create(MediaId, "user-1", "first");

        var act = () => comment.Edit("user-2", "hacked");

        act.Should().Throw<ForbiddenDomainException>();
    }

    [Fact]
    public void Comment_text_is_required()
    {
        var act = () => Comment.Create(MediaId, "user-1", " ");

        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Owner_can_change_a_rate()
    {
        var rate = Rate.Create(MediaId, "user-1", ScoreEnum.Two);

        rate.ChangeScore("user-1", ScoreEnum.Five);

        rate.Score.Should().Be(ScoreEnum.Five);
    }

    [Fact]
    public void Other_users_cannot_change_a_rate()
    {
        var rate = Rate.Create(MediaId, "user-1", ScoreEnum.Two);

        var act = () => rate.ChangeScore("user-2", ScoreEnum.Five);

        act.Should().Throw<ForbiddenDomainException>();
    }
}
