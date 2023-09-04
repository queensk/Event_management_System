using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_management_System.Model;

namespace Event_management_System.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    
        public ICollection<Event> RegisteredEvents { get; set; } = new List<Event>();

    }
}