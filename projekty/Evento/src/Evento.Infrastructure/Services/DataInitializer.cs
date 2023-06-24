using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        public DataInitializer(IUserService userService, IEventService eventService)
        {
            _eventService = eventService;
            _userService = userService; 
        }
        public async Task SeedAsync()
        {
            var tasks = new List<Task>();
            tasks.Add(_userService.RegisterAsync(Guid.NewGuid(), "user@email.com", "defaul user", "secret"));
            tasks.Add(_userService.RegisterAsync(Guid.NewGuid(), "admin@email.com", "defaul user", "secret", "admin"));
            for (var i = 1; i <= 10; i++) 
            {
                var eventId = Guid.NewGuid();
                var name = $"Event {i}";
                var description = $"{name} description.";
                var startDate = DateTime.UtcNow.AddHours(3);
                var endDate = startDate.AddHours(2);
                tasks.Add(_eventService.CreateAsync(eventId, name, description, startDate, endDate));
                tasks.Add(_eventService.AddTicketAsync(eventId, 1000, 100));
            }
            await Task.WhenAll(tasks);
        }
    }
}
