using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_management_System.Model
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public double TicketAmount  { get; set; }
        public DateTime StartDate { get; set; }
        [InverseProperty(nameof(User.RegisteredEvents))]
        public ICollection<User> RegisteredUsers { get; set; } = new List<User>();

    }


}