using IMDB.Domain.Entities;

namespace IMDB.Domain.Repositories;

public interface ICommentRepository : IRepository<Comment>
{
    Task<IReadOnlyList<Comment>> GetByMediaIdAsync(Guid mediaId, CancellationToken cancellationToken = default);
}
