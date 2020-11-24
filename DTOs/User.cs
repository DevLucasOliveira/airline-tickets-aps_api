namespace AirlineTickets.Api.DTOs
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public static implicit operator User(Models.User entity)
        {
            return new User
            {
                Id = entity.Id.ToString(),
                Email = entity.Email,
                Token = entity.Token,
            };
        }

    }
}
