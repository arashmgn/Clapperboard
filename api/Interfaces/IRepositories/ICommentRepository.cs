using IMDB.Domain.Entities;

namespace api.Interfaces.IRepositories;

public interface ICommentRepository:IRepository<Comment>
{
    public Task<List<Comment>> GetMediaCommentsAsync(int mediaId);
}
