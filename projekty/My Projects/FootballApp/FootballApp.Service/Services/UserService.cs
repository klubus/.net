using FootballApp.Data.Models;
using FootballApp.Service.Interface.Services;
using Microsoft.AspNetCore.Identity;

namespace FootballApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> IsUserExists(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user != null)
            {
                return true;

            }
            return false;
        }

        public async Task<IdentityUser> AddUser(UserModel registerUser)
        {
            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
            };

            await _userManager.CreateAsync(user, registerUser.Password);
            return user;
        }

        public async Task<bool> AddRoleToUser(IdentityUser user, string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(user, role);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
