﻿using AutoMapper;
using Football.Infrastructure.DTO;

namespace Football.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EventService(IEventRepository eventRepository, IMapper mapper, ILogger<EventService> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EventDto> GetAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);

            return _mapper.Map<EventDto>(@event);
        }

        public async Task<EventDto> GetAsync(string name)
        {
            var @event = await _eventRepository.GetAsync(name);

            return _mapper.Map<EventDto>(@event);
        }
        public async Task<IEnumerable<EventDto>> BrowseAsync(string name = null)
        {
            _logger.LogTrace("Fetching events");

            var events = await _eventRepository.BrowseAsync(name);

            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task AddTicketAsync(Guid id, int amount, decimal price)
        {
            var @event = await _eventRepository.GetOrFailAsync(id);
            @event.AddTickets(amount, price);
            await _eventRepository.UpdateAsync(@event);

        }

        public async Task CreateAsync(Guid id, string name, string description, DateTime startDate, DateTime endDate)
        {
            var @event = await _eventRepository.GetAsync(name);

            if (@event != null)
            {
                throw new Exception($"Event named: {name} already exists.");
            }

            @event = new Event(id, name, description, startDate, endDate);
            await _eventRepository.AddAsync(@event);
        }

        public async Task UpdateAsync(Guid id, string name, string description)
        {
            var @event = await _eventRepository.GetOrFailAsync(id);

            if (@event != null)
            {
                throw new Exception($"Event named: {name} already exists.");
            }

            @event = await _eventRepository.GetAsync(name);
            @event.SetName(name);
            @event.SetDescription(description);
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task DeleteAsync(Guid id)
        {
            var @event = await _eventRepository.GetOrFailAsync(id);
            await _eventRepository.DeleteAsync(@event);

        }

    }
}
