using FootballApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FootballApp.Service.Interface.Services
{
    public interface IUserService
    {
        Task<bool> IsUserExists(string userEmail);
        Task<IdentityUser> AddUser(UserModel registerUser);
        Task<bool> AddRoleToUser(IdentityUser user, string role);
        JwtSecurityToken GetToken(List<Claim> authClaims);
        Task AddClaimToRole(IdentityUser user, List<Claim> authClaims);

    }
}
