namespace IMDB.Application.Features.Account.Commands.Register;
public record RegisterCommand(string UserName, string Email, string Password) : IRequest<NewUserDto>;
