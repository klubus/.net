using FootballApp.Data.Entities;

namespace FootballApp.Service.Interface.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeams();
        Task<Team> GetTeamById(int id);
        Task AddTeam(Team team);
        Task EditTeam(Team team);
        Task DeleteTeam(int id);

        // przygotować automapper do zmapowania na TeamDto
    }
}
