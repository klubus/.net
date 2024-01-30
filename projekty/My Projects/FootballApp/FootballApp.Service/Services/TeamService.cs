using AutoMapper;
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

        //poprawić, żeby zwracał Dto
        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await _dataContext.Teams.ToListAsync();
        }

        public async Task<TeamResponseDto> GetTeamById(int id)
        {
            var team = await _dataContext.Teams.FirstOrDefaultAsync(t => t.Id == id);

            return _mapper.Map<TeamResponseDto>(team);
        }

        public async Task AddTeam(Team team)
        {
            await _dataContext.Teams.AddAsync(team);
            await _dataContext.SaveChangesAsync();
        }

        public async Task EditTeam(Team team)
        {
            var singleTeam = await GetTeamById(team.Id);

            singleTeam.Id = team.Id;
            singleTeam.Name = team.Name;
            singleTeam.League.Name = team.League.Name;
            singleTeam.YearOfFunded = team.YearOfFunded;

            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteTeam(int id)
        {
            var team = await _dataContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
            _dataContext.Teams.Remove(team);
            await _dataContext.SaveChangesAsync();
        }

    }
}
