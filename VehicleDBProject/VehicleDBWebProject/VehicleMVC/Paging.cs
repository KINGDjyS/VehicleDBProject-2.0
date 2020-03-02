using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleMVC
{
    public class Paging
    {
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; }
        public int Elements { get; set; } 
        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

    }
}
