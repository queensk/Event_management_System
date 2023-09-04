using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_management_System.Data;
using Event_management_System.Model;
using Event_management_System.Responses;
using Event_management_System.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace Event_management_System.Services
{
    public class EventService : IEventService
    {

        private readonly AppDbContext _context;
        public EventService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddEventAsync(Event availableEvent)
        {
            _context.Events.Add(availableEvent);
            await _context.SaveChangesAsync();
            return "Event added successfully";
        }

        public async Task<string> DeleteEventAsync(Event availableEvent)
        {
            _context.Events.Remove(availableEvent);
            await _context.SaveChangesAsync();
            return "Event deleted successfully";
        }

        public Task<string> DeleteEventAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        // get all events
        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.Include(e => e.RegisteredUsers).ToListAsync();
        }

        public async Task<(List<Event>, PaginationMetadata)> GetAllAsync(string name, string location, DateTime startDate, string description, int pageSize, int pageNumber)
        {
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(location) && startDate == default(DateTime) && string.IsNullOrWhiteSpace(description))
            {
                // No search string or filter
                var eventList = await GetAllEventsAsync();
                var totalEventCount = eventList.Count();
                eventList = eventList.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                var paginationEventMetadata = new PaginationMetadata(pageSize, pageNumber, totalEventCount);
                return (eventList, paginationEventMetadata);
            }

            // Build the query
            var query = _context.Events.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(e => e.Name.ToLower().Contains(name.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(e => e.Location.ToLower().Contains(location.ToLower()));
            }

            if (startDate != default(DateTime))
            {
                query = query.Where(e => e.StartDate >= startDate);
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                query = query.Where(e => e.Description.ToLower().Contains(description.ToLower()));
            }

            query = query.Include(u => u.RegisteredUsers).OrderByDescending(e => e.StartDate);
            var totalCount = await query.CountAsync();

            // Pagination
            query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            var paginationMetadata = new PaginationMetadata(pageSize, pageNumber, totalCount);

            // Execute the query
            return (await query.ToListAsync(), paginationMetadata);
        }

        public async Task<int> GetAvailableSlotsAsync(Guid eventId)
        {
            var events = await _context.Events
                                .Include(e => e.RegisteredUsers)
                                .FirstOrDefaultAsync(e => e.Id == eventId);
            if (events == null)
            {
                return 0;
            }
            int availableEvent = events.Capacity - events.RegisteredUsers.Count();
            return availableEvent;
        }

        public async Task<Event> GetEventByIdAsync(Guid id)
        {
          return await _context.Events.Include(u => u.RegisteredUsers).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetRegisteredUsersAsync(Guid eventId)
        {
            // get all registered users for an event
            _context.Events.Include(e => e.RegisteredUsers);
            return  await _context.Events.Where(e => e.Id == eventId).SelectMany(e => e.RegisteredUsers).ToListAsync();
        }

        public async Task<List<Event>> SearchEventsByLocationAsync(string location)
        {
            return await _context.Events
                .Where(e => e.Location == location)
                .ToListAsync();
        }


        public async Task<string> UpdateEventAsync(Event availableEvent)
        {
            _context.Events.Update(availableEvent);
            await _context.SaveChangesAsync();
            return "Event updated successfully";
        }
    }
}