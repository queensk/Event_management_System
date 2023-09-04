using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
﻿using Event_management_System.Model;
using Event_management_System.Responses;

namespace Event_management_System.Services.IService
{
    public interface IEventService
    {
        Task<string> AddEventAsync(Event availableEvent);
        Task<string> DeleteEventAsync(Event availableEvent);
        Task<(List<Event>, PaginationMetadata)> GetAllAsync(string name, string location, DateTime startDate, string description, int pageSize, int pageNumber);
        Task<int> GetAvailableSlotsAsync(Guid eventId);
        Task<Event> GetEventByIdAsync(Guid id);
        Task<List<User>> GetRegisteredUsersAsync(Guid eventId);
        Task<List<Event>> SearchEventsByLocationAsync(string location);
        Task<string> UpdateEventAsync(Event availableEvent);
    }
}