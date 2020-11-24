using AirlineTickets.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTickets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser(
             [FromServices] IUserRepository repository,
             [FromBody] RegisterUserCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult AuthenticateUser(
            [FromServices] IUserRepository repository,
            [FromBody] AuthenticateUserCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
