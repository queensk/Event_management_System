using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_management_System.Responses
{
    public class UserSuccess
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public UserSuccess(int c , string m)
        {
            this.Code = c;
            this.Message = m;
        }
    }
}