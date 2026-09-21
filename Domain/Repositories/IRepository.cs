using IMDB.Domain.Common;

namespace IMDB.Domain.Repositories;

public interface IRepository<T> where T : AggregateRoot
{
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllByIdsAsync(IEnumerable<int> ids);
    Task<(List<T>, int)> GetAllPaginatedAsync(int page, int pageSize);
    Task<T?> AddAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}
