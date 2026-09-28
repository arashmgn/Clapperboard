using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Queries.GetCommentsPaginated;

public class GetCommentsPaginatedQueryHandler : IRequestHandler<GetCommentsPaginatedQuery, (List<Comment> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetCommentsPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<Comment> Items, int TotalCount)> Handle(GetCommentsPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Comments.CountAsync(cancellationToken);

        var items = await _context.Comments
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
