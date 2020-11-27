using Flunt.Notifications;
using Flunt.Validations;

namespace AirlineTickets.Api.Commands
{
    public class RegisterUserCommand : Notifiable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Email inválido"));
        }

    }
}
