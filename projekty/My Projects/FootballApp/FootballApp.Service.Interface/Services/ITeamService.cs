using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos;

namespace FootballApp.Service.Interface.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeams();
        Task<TeamDto> GetTeamById(int id);
        Task AddTeam(Team team);
        Task EditTeam(Team team);
        Task DeleteTeam(int id);

    }
}
