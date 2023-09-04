using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_management_System.Responses
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}