using Football.Infrastructure.DTO;

namespace Football.Infrastructure.Services
{
    public interface ITeamService
    {
        Task<TeamDTO> GetAsync(Guid id);
        Task<TeamDTO> GetAsync(string name);
    }
}
