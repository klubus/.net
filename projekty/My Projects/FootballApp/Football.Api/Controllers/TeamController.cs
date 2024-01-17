using FootballApp.Data.Entities;
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
            _logger.LogInformation("Hii");
            _logger.LogTrace("Hii");

            return Ok(await _teamService.GetAllTeams());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> Get(int id)
        {
            return Ok(await _teamService.GetTeamById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Team>>> AddTeam([FromBody] Team team)
        {
            await _teamService.AddTeam(team);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<Team>>> UpdateTeam([FromBody] Team team)
        {
            await _teamService.EditTeam(team);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> Delete(int id)
        {
            await _teamService.DeleteTeam(id);
            return Ok();
        }

    }
}
