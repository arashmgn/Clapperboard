namespace IMDB.Application.Features.Account.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, NewUserDto>
{
    private readonly IIdentityService _identity;
    private readonly ITokenService _tokens;

    public RegisterCommandHandler(IIdentityService identity, ITokenService tokens)
    {
        _identity = identity;
        _tokens = tokens;
    }

    public async Task<NewUserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await _identity.RegisterAsync(request.UserName, request.Email, request.Password, cancellationToken);

        return new NewUserDto(user.UserName, user.Email, _tokens.CreateToken(user));
    }
}
