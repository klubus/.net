namespace Football.Core.Domain
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearOfFounded { get; set; }
    }
}
