using AirlineTickets.Api.ValueObjects;
using System;

namespace AirlineTickets.Api.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string email, string name, Password password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            PasswordHash = password.PasswordHash;
            PasswordSalt = password.PasswordSalt;
        }

        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
    }
}
