namespace IMDB.Application.Features.Account.Commands.Login;
public record LoginCommand(string UserName, string Password) : IRequest<NewUserDto>;
