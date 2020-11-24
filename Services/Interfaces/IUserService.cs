using AirlineTickets.Api.Commands;

namespace AirlineTickets.Api.Services.Interfaces
{
    public interface IUserService
    {
        GenericCommandResult Register(RegisterUserCommand command);
        GenericCommandResult Authenticate(AuthenticateUserCommand command);
    }
}
