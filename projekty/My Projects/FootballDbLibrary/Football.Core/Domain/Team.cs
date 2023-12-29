namespace Football.Core.Domain
{
    public class Team : Entity
    {
        public string Name { get; protected set; }
        public string Country { get; protected set; }
        public int YearOfFounded { get; protected set; }
    }
}
