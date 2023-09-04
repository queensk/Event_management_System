using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_management_System.Requests
{
    public class EventFilterParameters
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public DateTime StartDate { get; set; }
        public string? Description { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}