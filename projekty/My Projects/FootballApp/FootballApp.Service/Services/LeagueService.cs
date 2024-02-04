using AutoMapper;
using FootballApp.Common.Framework;
using FootballApp.Common.Framework.Interface;
using FootballApp.Data.Contexts;
using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos.LeagueDtos;
using FootballApp.Service.Interface.Services;
using Microsoft.EntityFrameworkCore;

namespace FootballApp.Service.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly DatabaseContext _dataContext;
        private readonly IMapper _mapper;

        public LeagueService(DatabaseContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LeagueResponseDto>> GetAllLeagues()
        {
            var allLeagues = await _dataContext.Leagues.ToListAsync();

            return _mapper.Map<IEnumerable<LeagueResponseDto>>(allLeagues);
        }
        public async Task<IActionResult<LeagueResponseDto>> AddLeague(CreateLeagueDto request)
        {
            var league = _mapper.Map<League>(request);

            await _dataContext.Leagues.AddAsync(league);
            await _dataContext.SaveChangesAsync();

            var leagueResponseDto = _mapper.Map<LeagueResponseDto>(league);

            return ActionResult<LeagueResponseDto>.Success(leagueResponseDto);
        }
    }
}
