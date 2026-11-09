using IMDB.Domain.Entities;

namespace IMDB.Domain.Repositories;

public interface ICastRepository : IRepository<Cast>
{
    Task<IReadOnlyList<Cast>> GetByMediaIdAsync(Guid mediaId, CancellationToken cancellationToken = default);

    Task<(IReadOnlyList<Cast> Items, int TotalCount)> GetPagedByMediaIdAsync(Guid mediaId, int page, int pageSize, CancellationToken cancellationToken = default);
}
