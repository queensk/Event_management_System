using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Event_management_System.Requests
{
    public class AddEvent
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public double TicketAmount  { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
    }
}