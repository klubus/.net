using Football.Core.Domain;
using Football.Core.Repositories;

namespace Football.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private static readonly ISet<Team> _teams = new HashSet<Team>()
        {
            new Team(Guid.NewGuid(), "Barca", "Spain", 1999),

        };
        public async Task<Team> GetAsync(Guid id)
        {
            return await Task.FromResult(_teams.FirstOrDefault(t => t.Id == id));
        }

        public async Task<Team> GetAsync(string name)
        {
            return await Task.FromResult(_teams.FirstOrDefault(t => t.Name.ToLowerInvariant() == name.ToLowerInvariant()));
        }

        public async Task AddAsync(Team team)
        {
            _teams.Add(team);
            await Task.CompletedTask;
        }


        public async Task DeleteAsync(Team team)
        {
            _teams.Remove(team);
            await Task.CompletedTask;
        }


        public async Task UpdateAsync(Team team)
        {
            await Task.CompletedTask;
        }
    }
}
