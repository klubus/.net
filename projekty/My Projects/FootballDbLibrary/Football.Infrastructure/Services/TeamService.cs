using Football.Infrastructure.DTO;

namespace Football.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamService _service;

        public TeamService(ITeamService service)
        {
            _service = service;
        }
        public async Task<TeamDTO> GetAsync(Guid id)
        {
            var team = await _service.GetAsync(id);

            return new TeamDTO
            {
                Name = team.Name,
                Country = team.Country,
                YearOfFounded = team.YearOfFounded,
            };
        }

        public async Task<TeamDTO> GetAsync(string name)
        {
            var team = await _service.GetAsync(name);

            return new TeamDTO
            {
                Name = team.Name,
                Country = team.Country,
                YearOfFounded = team.YearOfFounded,
            };
        }

        public Task<TeamDTO> AddAsync(Guid id, string name, string country, int yearOfFounded)
        {
            throw new NotImplementedException();
        }

        public Task<TeamDTO> UpdateAsync(Guid id, string name, string country, int yearOfFounded)
        {
            throw new NotImplementedException();
        }

        public Task<TeamDTO> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
