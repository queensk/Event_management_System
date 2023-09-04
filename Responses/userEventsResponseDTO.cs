using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_management_System.Responses
{
    public class UserEventsResponseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public double TicketAmount  { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<EventUserResponseDTO> RegisteredUsers { get; set; } 
    }

    public class EventUserResponseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}