using AirlineTickets.Api.Models;

namespace AirlineTickets.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Register(User user);
        User Authenticate(string user);
        bool UserExists(string email);
    }
}
