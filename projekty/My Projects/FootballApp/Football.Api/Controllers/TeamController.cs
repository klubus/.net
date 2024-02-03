using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos.TeamDtos;
using FootballApp.Service.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly DatabaseContext _dataContext;
        private readonly ILogger<TeamController> _logger;

        public ITeamService _teamService { get; }

        public TeamController(DatabaseContext context, ITeamService teamService, ILogger<TeamController> logger)
        {
            _dataContext = context;
            _teamService = teamService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> Get()
        {
            _logger.LogInformation("Hitting {endpoint}", GetType().FullName);

            return Ok(await _teamService.GetAllTeams());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> Get(int id)
        {
            _logger.LogInformation("Get Teams by Id - started");

            return Ok(await _teamService.GetTeamById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Team>>> AddTeam([FromBody] CreateTeamDto request)
        {
            _logger.LogInformation("Hitting {endpoint} with [{body}]: [{@body}]",
                AddTeam, nameof(CreateTeamDto), request);

            await _teamService.AddTeam(request);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<Team>>> UpdateTeam([FromBody] EditTeamDto team)
        {
            _logger.LogInformation("Hitting {endpoint} with [{body}]: [{@body}]",
                UpdateTeam, nameof(EditTeamDto), team);
            await _teamService.EditTeam(team);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> Delete(int id)
        {
            _logger.LogInformation("Hitting {endpoint} with {id}", GetType().FullName, id);

            await _teamService.DeleteTeam(id);
            return Ok();
        }

    }
}
