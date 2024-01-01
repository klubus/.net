using Football.Api.Models;

namespace Football.Api.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly DataContext _dataContext;

        public TeamService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await _dataContext.Teams.ToListAsync();
        }

        public async Task<Team> GetTeamById(int id)
        {
            return _dataContext.Teams.FirstOrDefault(t => t.Id == id);
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
            singleTeam.Country = team.Country;
            singleTeam.YearOfFunded = team.YearOfFunded;

            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteTeam(int id)
        {
            var singleTeam = await GetTeamById(id);
            _dataContext.Teams.Remove(singleTeam);
            await _dataContext.SaveChangesAsync();
        }


    }
}
