using FootballApp.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace FootballApp.Service.Interface.Services
{
    public interface IUserService
    {
        Task<bool> IsUserExists(string userEmail);
        Task<IdentityUser> AddUser(UserModel registerUser);
        Task<bool> AddRoleToUser(IdentityUser user, string role);

    }
}
