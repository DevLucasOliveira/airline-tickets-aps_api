using AirlineTickets.Api.Models;
using System;
using System.Linq.Expressions;

namespace AirlineTickets.Api.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> UserExists(string email)
        {
            return x => x.Email == email;
        }
        public static Expression<Func<User, bool>> Authenticate(string user)
        {
            return x => x.Email == user;
        }

    }
}
