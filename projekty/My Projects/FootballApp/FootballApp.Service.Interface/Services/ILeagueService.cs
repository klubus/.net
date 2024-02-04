using FootballApp.Common.Framework.Interface;
using FootballApp.Dto.Dtos.LeagueDtos;

namespace FootballApp.Service.Interface.Services
{
    public interface ILeagueService
    {
        Task<IEnumerable<LeagueResponseDto>> GetAllLeagues();
        Task<IActionResult<LeagueResponseDto>> AddLeague(CreateLeagueDto league);
    }
}
