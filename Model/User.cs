using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Event_management_System.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get;set; }="User";

        [InverseProperty(nameof(Event.RegisteredUsers))]
        public ICollection<Event> RegisteredEvents { get; set; } = new List<Event>();
        
    }
}