using Football.Core.Domain;

namespace Football.Core.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> GetAsync(Guid id);
        Task<Team> GetAsync(string name);
        Task AddAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(Team team);

    }
}
