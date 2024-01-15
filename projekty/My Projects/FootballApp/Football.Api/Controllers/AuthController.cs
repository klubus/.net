using FootballApp.Data.Models;
using FootballApp.Dto.Dtos;
using FootballApp.Service.Interface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Football.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IUserService userService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        [HttpPost("register"), AllowAnonymous]
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

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto login)
        {
            // checking the user
            var user = await _userManager.FindByNameAsync(login.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var jwtToken = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                });
            }

            return Unauthorized();

        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddHours(12),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

    }
}
