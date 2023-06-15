using Evento.Infrastructure.Commands.Users;
using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("tickets")]
        public async Task<IActionResult> GetTickets()
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(Register command)
        {
            await _userService.RegisterAsync(command.Id, command.Email, command.Name, command.Password, command.Role);
            return Created("/account", null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post(Login command)
         => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}
