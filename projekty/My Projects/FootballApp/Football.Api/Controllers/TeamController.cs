using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos.TeamDtos;
using FootballApp.Service.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

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


        /// <summary>
        /// Get All Teams
        /// </summary>
        /// <returns> <see cref="Team"/> id</returns>
        /// <response code="200">OK</response>
        /// <response code="403">User is not authorized to invoke endpoint</response>
        /// <response code="500">Any exception</response>  
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<List<Team>>> Get()
        {
            _logger.LogInformation("Hitting {endpoint}", GetType().FullName);

            return Ok(await _teamService.GetAllTeams());
        }

        /// <summary>
        /// Get Single Team
        /// </summary>
        /// <returns> <see cref="Team"/> id</returns>
        /// <response code="200">OK</response>
        /// <response code="403">User is not authorized to invoke endpoint</response>
        /// <response code="500">Any exception</response>  
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> Get(int id)
        {
            _logger.LogInformation("Hitting {endpoint}", GetType().FullName);

            return Ok(await _teamService.GetTeamById(id));
        }

        /// <summary>
        /// Get All Teams from League
        /// </summary>
        /// <returns> <see cref="Team"/> id</returns>
        /// <response code="200">OK</response>
        /// <response code="403">User is not authorized to invoke endpoint</response>
        /// <response code="500">Any exception</response>  
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status500InternalServerError)]
        [Route("GetTeamsFromLeague")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeamsFromLeague(int leagueId)
        {
            _logger.LogInformation("Hitting {endpoint}", GetType().FullName);

            var teams = await _teamService.GetTeamsFromLeague(leagueId);

            return Ok(teams);
        }


        /// <summary>
        /// Creates Team based on given CreateTeamDto
        /// </summary>
        /// <param name="request"><see cref="CreateTeamDto"/></param>
        /// <returns>Created <see cref="Team"/> number.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request, action forbidden</response>
        /// <response code="404">Resource not found</response>
        /// <response code="409">The request could not be completed due to a conflict with the current state of target resource.</response>
        /// <response code="500">Any exception</response>
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status409Conflict)]
        [ProducesResponseType(Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<List<Team>>> AddTeam([FromBody] CreateTeamDto request)
        {
            _logger.LogInformation("Hitting {endpoint} with [{body}]: [{@body}]",
                AddTeam, nameof(CreateTeamDto), request);

            var result = await _teamService.AddTeam(request);
            return result.IsSuccess
                ? Ok(result.Data)
                : BadRequest(result.ErrorMessage);
        }

        /// <summary>
        /// Edit Team based on given EditTeamDto
        /// </summary>
        /// <param name="team"><see cref="EditTeamDto"/></param>
        /// <returns>Created <see cref="Team"/> number.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request, action forbidden</response>
        /// <response code="404">Resource not found</response>
        /// <response code="409">The request could not be completed due to a conflict with the current state of target resource.</response>
        /// <response code="500">Any exception</response>
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status409Conflict)]
        [ProducesResponseType(Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<List<Team>>> UpdateTeam([FromBody] EditTeamDto team)
        {
            _logger.LogInformation("Hitting {endpoint} with [{body}]: [{@body}]",
                UpdateTeam, nameof(EditTeamDto), team);

            var result = await _teamService.EditTeam(team);

            return result.IsSuccess
                ? Ok(result.Data)
                : BadRequest(result.ErrorMessage);
        }

        /// <summary>
        /// Delete Team
        /// </summary>
        /// <returns> <see cref="Team"/> id</returns>
        /// <response code="200">OK</response>
        /// <response code="403">User is not authorized to invoke endpoint</response>
        /// <response code="500">Any exception</response>  
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> Delete(int id)
        {
            _logger.LogInformation("Hitting {endpoint} with {id}", GetType().FullName, id);

            await _teamService.DeleteTeam(id);
            return Ok();
        }

    }
}
