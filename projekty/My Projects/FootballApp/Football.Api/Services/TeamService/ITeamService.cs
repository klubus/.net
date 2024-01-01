using Football.Api.Models;

namespace Football.Api.Services.TeamService
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeams();
        Task<Team> GetTeamById(int id);
        Task AddTeam(Team team);
        Task EditTeam(Team team);
        Task DeleteTeam(int id);

    }
}
