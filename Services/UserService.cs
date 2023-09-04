using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Event_management_System.Data;
using Event_management_System.Model;
using Event_management_System.Requests;
using Event_management_System.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace Event_management_System.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IEventService _eventService;
        public UserService(AppDbContext context)
        {
            _context = context;
            _eventService = new EventService(_context);
        }

        public async Task<string> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User added successfully";
        }

        public async Task<string> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return "User deleted successfully";
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.RegisteredEvents).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.Include(u => u.RegisteredEvents).Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<string> RegisterEventAsync(RegisterEvent registerEvent)
        {
            var user = _context.Users.Where(u => u.Id == registerEvent.UserId).FirstOrDefault();
            var event1 = _context.Events.Where(e => e.Id == registerEvent.EventId).FirstOrDefault();
            // available slots is greater than 0
            int availableSlots = await _eventService.GetAvailableSlotsAsync(registerEvent.EventId);
            if (user != null && event1 != null )
            {
                if (availableSlots > 0)
                {
                    user.RegisteredEvents.Add(event1);
                    await _context.SaveChangesAsync();
                    return "Registered successfully";
                }
                return "No available slots";
            }

            return "User or Event not found";
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return "User updated successfully";
        }

        public async Task<User> GetUserByEmailAsync(string Email)
        {
            var user = await _context.Users.Where(u => u.Email == Email).FirstOrDefaultAsync();
            return user;
        }
    }
}
