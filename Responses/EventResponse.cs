using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_management_System.Model;

namespace Event_management_System.Responses
{
    public class EventResponse
    {
        public IEnumerable<Event> Events { get; set; }
        public PaginationMetadata Metadata { get; set; }
    }
}