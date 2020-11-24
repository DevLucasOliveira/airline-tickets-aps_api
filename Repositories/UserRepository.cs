using AirlineTickets.Api.Data;
using AirlineTickets.Api.Models;
using AirlineTickets.Api.Queries;
using AirlineTickets.Api.Repositories.Interfaces;
using System.Linq;

namespace AirlineTickets.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User Authenticate(string user)
        {
            return _context.User.FirstOrDefault(UserQueries.Authenticate(user));
        }

        public void Register(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public bool UserExists(string email)
        {
            return _context.User.Any(UserQueries.UserExists(email));
        }


    }
}
