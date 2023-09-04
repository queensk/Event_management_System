using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_management_System.Requests
{
    public class RegisterEvent
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
    }
}