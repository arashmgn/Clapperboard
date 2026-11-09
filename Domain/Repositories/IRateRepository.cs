using IMDB.Domain.Entities;

namespace IMDB.Domain.Repositories;

public interface IRateRepository : IRepository<Rate>
{
    Task<IReadOnlyList<Rate>> GetByMediaIdAsync(Guid mediaId, CancellationToken cancellationToken = default);
}
