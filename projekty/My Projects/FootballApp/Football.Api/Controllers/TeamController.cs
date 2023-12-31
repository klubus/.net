using Football.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly DataContext _context;

        public TeamController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> Get()
        {

            return Ok(await _context.Teams.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> Get(int id)
        {
            var singleTeam = _context.Teams.FirstOrDefault(t => t.Id == id);
            if (singleTeam == null)
            {
                return NotFound();
            }
            return Ok(singleTeam);
        }

        [HttpPost]
        public async Task<ActionResult<List<Team>>> AddTeam([FromBody] Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<Team>>> UpdateTeam([FromBody] Team team)
        {
            var singleTeam = _context.Teams.FirstOrDefault(t => t.Id == team.Id);
            if (singleTeam == null)
            {
                return NotFound();
            }
            singleTeam.Id = team.Id;
            singleTeam.Name = team.Name;
            singleTeam.Country = team.Country;
            singleTeam.YearOfFunded = team.YearOfFunded;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> Delete(int id)
        {
            var singleTeam = _context.Teams.FirstOrDefault(t => t.Id == id);
            if (singleTeam == null)
            {
                return NotFound();
            }
            _context.Teams.Remove(singleTeam);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
