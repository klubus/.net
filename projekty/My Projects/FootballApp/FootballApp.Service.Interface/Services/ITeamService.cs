using FootballApp.Common.Framework.Interface;
using FootballApp.Dto.Dtos.TeamDtos;

namespace FootballApp.Service.Interface.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamResponseDto>> GetAllTeams();
        Task<TeamResponseDto> GetTeamById(int id);
        Task<IEnumerable<TeamResponseDto>> GetTeamsFromLeague(int leagueId);

        Task<IActionResult<TeamResponseDto>> AddTeam(CreateTeamDto team);
        Task<IActionResult<TeamResponseDto>> EditTeam(EditTeamDto team);
        Task DeleteTeam(int id);

    }
}
