using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_management_System.Responses
{
    public class PaginationMetadata
    {
        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int CurrentPage { get; set; } 

        public int TotalCount { get; set; }

        public PaginationMetadata (int ps, int cp, int tc)
        {
            this.PageSize = ps;
            this.CurrentPage = cp;  
            this.TotalCount = tc;
            this.PageCount =(int) Math.Ceiling((double)tc /(double) ps);
        }
    }
}