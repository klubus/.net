using Football.Infrastructure.DTO;

namespace Football.Infrastructure.Services
{
    public interface ITeamService
    {
        Task<TeamDTO> GetAsync(Guid id);
        Task<TeamDTO> GetAsync(string name);
        Task<TeamDTO> AddAsync(Guid id, string name, string country, int yearOfFounded);
        Task<TeamDTO> UpdateAsync(Guid id, string name, string country, int yearOfFounded);
        Task<TeamDTO> DeleteAsync(Guid id);
    }
}
