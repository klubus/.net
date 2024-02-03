using FootballApp.Data.Entities;

namespace FootballApp.Dto.Dtos.TeamDtos
{
    public class TeamResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public League LeagueId { get; set; }
        public int YearOfFunded { get; set; }
    }
}
