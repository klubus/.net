using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos.TeamDtos;

namespace FootballApp.Service.Interface.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeams();
        Task<TeamResponseDto> GetTeamById(int id);
        Task AddTeam(CreateTeamDto team);
        Task EditTeam(EditTeamDto team);
        Task DeleteTeam(int id);

    }
}
