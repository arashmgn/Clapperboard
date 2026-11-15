namespace IMDB.Application.Features.Account.Commands.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, NewUserDto>
{
    private readonly IIdentityService _identity;
    private readonly ITokenService _tokens;

    public LoginCommandHandler(IIdentityService identity, ITokenService tokens)
    {
        _identity = identity;
        _tokens = tokens;
    }

    public async Task<NewUserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _identity.ValidateCredentialsAsync(request.UserName, request.Password, cancellationToken);

        return new NewUserDto(user.UserName, user.Email, _tokens.CreateToken(user));
    }
}
