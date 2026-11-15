using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Comments.Queries.GetMediaComments;
public class GetMediaCommentsQueryHandler : IRequestHandler<GetMediaCommentsQuery, List<CommentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetMediaCommentsQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<List<CommentDto>> Handle(GetMediaCommentsQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.Comments
            .AsNoTracking()
            .Where(x => x.MediaId == request.MediaId)
            .OrderBy(x => x.CreatedOn)
            .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return await _identity.WithUserNamesAsync(items, cancellationToken);
    }
}
