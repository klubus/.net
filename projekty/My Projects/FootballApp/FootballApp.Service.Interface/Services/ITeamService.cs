using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos.TeamDtos;

namespace FootballApp.Service.Interface.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeams();
        Task<TeamResponseDto> GetTeamById(int id);
        Task AddTeam(Team team);
        Task EditTeam(Team team);
        Task DeleteTeam(int id);

    }
}
