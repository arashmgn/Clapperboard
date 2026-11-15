using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Comments.Queries.GetComments;
public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<CommentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetCommentsQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<List<CommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.Comments
            .AsNoTracking()
            .OrderBy(x => x.CreatedOn)
            .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return await _identity.WithUserNamesAsync(items, cancellationToken);
    }
}
