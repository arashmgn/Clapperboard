namespace IMDB.Domain.Repositories;

public interface IMediaRepository
{
    Task<bool> ExistsAsync(Guid mediaId, CancellationToken cancellationToken = default);
}
