using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetCommentById;
public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment?>
{
    private readonly IApplicationDbContext _context;

    public GetCommentByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Comment?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Comments
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
