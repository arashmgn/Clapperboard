using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Comments.Queries.GetCommentsPaginated;
public class GetCommentsPaginatedQueryHandler : IRequestHandler<GetCommentsPaginatedQuery, (List<CommentDto> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetCommentsPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<(List<CommentDto> Items, int TotalCount)> Handle(GetCommentsPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Comments.CountAsync(cancellationToken);

        var items = await _context.Comments
            .AsNoTracking()
            .OrderBy(x => x.CreatedOn)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return (await _identity.WithUserNamesAsync(items, cancellationToken), totalCount);
    }
}
