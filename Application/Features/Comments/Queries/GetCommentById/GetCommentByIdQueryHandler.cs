using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Comments.Queries.GetCommentById;
public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetCommentByIdQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _context.Comments
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return await _identity.WithUserNameAsync(item, cancellationToken);
    }
}
