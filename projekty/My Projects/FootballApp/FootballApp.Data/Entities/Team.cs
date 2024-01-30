namespace FootballApp.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfFunded { get; set; }
        public League League { get; set; }
        public int LeagueId { get; set; }

    }
}
