using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos.LeagueDtos;
using FootballApp.Service.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;


namespace Football.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly DatabaseContext _dataContext;
        private readonly ILogger<LeagueController> _logger;

        public ILeagueService _leagueService { get; }

        public LeagueController(DatabaseContext context, ILeagueService leagueService, ILogger<LeagueController> logger)
        {
            _dataContext = context;
            _leagueService = leagueService;
            _logger = logger;
        }

        /// <summary>
        /// Get All Leagues
        /// </summary>
        /// <returns> <see cref="League"/> id</returns>
        /// <response code="200">OK</response>
        /// <response code="403">User is not authorized to invoke endpoint</response>
        /// <response code="500">Any exception</response>  
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<List<League>>> Get()
        {
            _logger.LogInformation("Hitting {endpoint}", GetType().FullName);

            return Ok(await _leagueService.GetAllLeagues());
        }


        /// <summary>
        /// Creates League based on given CreateLeagueDto
        /// </summary>
        /// <param name="request"><see cref="CreateLeagueDto"/></param>
        /// <returns>Created <see cref="League"/> number.</returns>
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
        public async Task<ActionResult<List<Team>>> AddLeague([FromBody] CreateLeagueDto request)
        {
            _logger.LogInformation("Hitting {endpoint} with [{body}]: [{@body}]",
                AddLeague, nameof(CreateLeagueDto), request);

            var result = await _leagueService.AddLeague(request);
            return result.IsSuccess
                ? Ok(result.Data)
                : BadRequest(result.ErrorMessage);
        }


    }
}
