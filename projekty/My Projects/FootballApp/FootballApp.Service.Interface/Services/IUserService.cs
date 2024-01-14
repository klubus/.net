using Microsoft.AspNetCore.Identity;

namespace FootballApp.Service.Interface.Services
{
    public interface IUserService
    {
        Task<IdentityUser> FindUserByEmail(string userEmail);

    }
}
