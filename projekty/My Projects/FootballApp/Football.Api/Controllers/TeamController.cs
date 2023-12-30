using Football.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private static List<Team> teams = new List<Team>
        {
            new Team
            {
                Name = "Barcelona",
                Country = "Spain",
                Id = 1,
                YearOfFunded = 1900
            },
            new Team
            {
                Name = "Arsenal",
                Country = "UK",
                Id = 2,
                YearOfFunded = 1955
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Team>>> Get()
        {

            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> Get(int id)
        {
            var singleTeam = teams.FirstOrDefault(t => t.Id == id);
            if (singleTeam == null)
            {
                return NotFound();
            }
            return Ok(singleTeam);
        }

        [HttpPost]
        public async Task<ActionResult<List<Team>>> AddTeam([FromBody] Team team)
        {
            teams.Add(team);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<Team>>> UpdateTeam([FromBody] Team team)
        {
            var singleTeam = teams.FirstOrDefault(t => t.Id == team.Id);
            if (singleTeam == null)
            {
                return NotFound();
            }
            singleTeam.Id = team.Id;
            singleTeam.Name = team.Name;
            singleTeam.Country = team.Country;
            singleTeam.YearOfFunded = team.YearOfFunded;
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> Delete(int id)
        {
            var singleTeam = teams.FirstOrDefault(t => t.Id == id);
            if (singleTeam == null)
            {
                return NotFound();
            }
            teams.Remove(singleTeam);
            return Ok();
        }

    }
}
