using FootballApp.Service.Interface.Services;
using Microsoft.AspNetCore.Identity;

namespace FootballApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityUser> FindUserByEmail(string userEmail)
        {
            return await _userManager.FindByEmailAsync(userEmail);
        }
    }
}
