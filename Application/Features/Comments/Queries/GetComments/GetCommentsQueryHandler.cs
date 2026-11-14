using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetComments;
public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<Comment>>
{
    private readonly IApplicationDbContext _context;

    public GetCommentsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Comments
            .AsNoTracking()
            .OrderBy(x => x.CreatedOn)
            .ToListAsync(cancellationToken);
    }
}
