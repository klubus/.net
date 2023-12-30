namespace Football.Core.Domain
{
    public class Event : Entity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }


        protected Event()
        {

        }

        public Event(Guid id, string name, string description, DateTime startDate, DateTime endDate)
        {
            Id = id;
            SetName(name);
            SetDescription(description);
            SetDates(startDate, endDate);
            EndDate = endDate;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetDates(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
            {
                throw new Exception($"Event with id: {Id} must have a end date greater than start date.");
            }
            StartDate = startDate;
            EndDate = endDate;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Event with {Id} cannot have an empty name.");
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception($"Event with {Id} cannot have an empty name.");
            }
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
