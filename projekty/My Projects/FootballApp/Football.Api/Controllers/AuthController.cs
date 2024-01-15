using FootballApp.Data.Models;
using FootballApp.Dto.Dtos;
using FootballApp.Service.Interface.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Football.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public AuthController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel registerUser, string role)
        {

            if (await _userService.IsUserExists(registerUser.Email))
            {
                return new ObjectResult("User already exists") { StatusCode = 403 };
            }

            var user = await _userService.AddUser(registerUser);

            if (await _userService.AddRoleToUser(user, role))
            {
                return new ObjectResult("User created") { StatusCode = 201 };

            }
            else
            {
                return new ObjectResult("User cannot be created") { StatusCode = 500 };
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                await _userService.AddClaimToRole(user, authClaims);

                var jwtToken = _userService.GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                });
            }

            return Unauthorized();
        }
    }
}
