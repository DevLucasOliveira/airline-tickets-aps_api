namespace AirlineTickets.Api.DTOs
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? Token { get; set; }

        public static implicit operator User(Models.User entity)
        {
            return new User
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Email = entity.Email,
                Token = entity.Token,
            };
        }

    }
}
