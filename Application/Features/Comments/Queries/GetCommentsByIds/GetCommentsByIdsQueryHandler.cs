using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetCommentsByIds;
public class GetCommentsByIdsQueryHandler : IRequestHandler<GetCommentsByIdsQuery, List<Comment>>
{
    private readonly IApplicationDbContext _context;

    public GetCommentsByIdsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> Handle(GetCommentsByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Comments
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}
