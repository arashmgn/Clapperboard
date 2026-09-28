using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Queries.GetMediaComments;

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
            .Where(x => x.TargetType == request.TargetType && x.TargetId == request.TargetId)
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync(cancellationToken);
    }
}
