using AirlineTickets.Api.Commands;
using AirlineTickets.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTickets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("register")]
        public GenericCommandResult RegisterUser(
             [FromServices] IUserService service,
             [FromBody] RegisterUserCommand command)
        {
            return service.Register(command);
        }

        [HttpPost]
        [Route("authenticate")]
        public GenericCommandResult AuthenticateUser(
            [FromServices] IUserService service,
            [FromBody] AuthenticateUserCommand command)
        {
            return service.Authenticate(command);
        }

    }
}
