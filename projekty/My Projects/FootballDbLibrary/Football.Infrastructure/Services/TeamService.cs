using AutoMapper;
using Football.Infrastructure.DTO;

namespace Football.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamService _service;
        private readonly IMapper _mapper;

        public TeamService(ITeamService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<TeamDTO> GetAsync(Guid id)
        {
            var team = await _service.GetAsync(id);

            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<TeamDTO> GetAsync(string name)
        {
            var team = await _service.GetAsync(name);

            return new TeamDTO
            {
                Name = name,
                Country = "Poland",
                YearOfFounded = 1992,
            };
        }

        //public Task AddAsync(Guid id, string name, string country, int yearOfFounded)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(Guid id, string name, string country, int yearOfFounded)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
