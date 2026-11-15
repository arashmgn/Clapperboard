using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Comments.Queries.GetCommentsByIds;
public class GetCommentsByIdsQueryHandler : IRequestHandler<GetCommentsByIdsQuery, List<CommentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetCommentsByIdsQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<List<CommentDto>> Handle(GetCommentsByIdsQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.Comments
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return await _identity.WithUserNamesAsync(items, cancellationToken);
    }
}
