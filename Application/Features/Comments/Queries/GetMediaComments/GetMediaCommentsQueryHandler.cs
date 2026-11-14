using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetMediaComments;
public class GetMediaCommentsQueryHandler : IRequestHandler<GetMediaCommentsQuery, List<Comment>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaCommentsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> Handle(GetMediaCommentsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Comments
            .AsNoTracking()
            .Where(c => c.MediaId == request.MediaId)
            .OrderBy(c => c.CreatedOn)
            .ToListAsync(cancellationToken);
    }
}
