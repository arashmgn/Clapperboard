using api.Dtos;
using api.Enums;
using api.Models;

namespace api.Interfaces.IRepositories;

public interface ICastRepository:IRepository<Cast>
{
    public Task<List<Cast>> GetMediaCastAsync(int mediaId);
    public Task<(List<Cast>, int)> GetMediaCastPaginatedAsync(int mediaId, int page, int pageSize);

}
