using Football.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _teamService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _teamRepository.AddAsync()
        }
    }
}
