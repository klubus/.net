using AutoMapper;
using FootballApp.Common.Framework;
using FootballApp.Common.Framework.Interface;
using FootballApp.Data.Contexts;
using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos.TeamDtos;
using FootballApp.Service.Interface.Services;
using Microsoft.EntityFrameworkCore;

namespace FootballApp.Service.Services
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext _dataContext;
        private readonly IMapper _mapper;

        public TeamService(DatabaseContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamResponseDto>> GetAllTeams()
        {
            var allTeams = await _dataContext.Teams.ToListAsync();

            return _mapper.Map<IEnumerable<TeamResponseDto>>(allTeams);
        }

        public async Task<TeamResponseDto> GetTeamById(int id)
        {
            var team = await _dataContext.Teams.FirstOrDefaultAsync(t => t.Id == id);

            return _mapper.Map<TeamResponseDto>(team);
        }
        public async Task<IEnumerable<TeamResponseDto>> GetTeamsFromLeague(int leagueId)
        {
            var teams = await _dataContext.Teams.Where(league => league.League.Id.ToString() == leagueId.ToString()).ToListAsync();

            return _mapper.Map<IEnumerable<TeamResponseDto>>(teams);
        }

        public async Task<IActionResult<TeamResponseDto>> AddTeam(CreateTeamDto team)
        {
            var newTeam = _mapper.Map<Team>(team);

            await _dataContext.Teams.AddAsync(newTeam);
            await _dataContext.SaveChangesAsync();

            var teamResponseDto = _mapper.Map<TeamResponseDto>(newTeam);

            return ActionResult<TeamResponseDto>.Success(teamResponseDto);
        }


        public async Task<IActionResult<TeamResponseDto>> EditTeam(EditTeamDto team)
        {
            var singleTeam = await _dataContext.Teams.FirstOrDefaultAsync(t => t.Id == team.Id);
            var league = await _dataContext.Leagues.FindAsync(team.LeagueId);

            singleTeam.Id = team.Id;
            singleTeam.Name = team.Name;
            singleTeam.YearOfFunded = team.YearOfFunded;
            singleTeam.LeagueId = league.Id;
            await _dataContext.SaveChangesAsync();

            var teamResponseDto = _mapper.Map<TeamResponseDto>(singleTeam);

            return ActionResult<TeamResponseDto>.Success(teamResponseDto);
        }
        public async Task DeleteTeam(int id)
        {
            var team = await _dataContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
            _dataContext.Teams.Remove(team);
            await _dataContext.SaveChangesAsync();
        }

    }
}
