﻿using Football.Core.Domain;

namespace Football.Core.Repositories
{
    public interface IEventRepository
    {
        Task<Event> GetAsync(Guid id);
        Task<Event> GetAsync(string name);
        Task<IEnumerable<Event>> BrowseAsync(string name = "");
        Task AddAsync(Event @event);
        Task UpdateAsync(Event @event);
        Task DeleteAsync(Event @event);
    }
}
