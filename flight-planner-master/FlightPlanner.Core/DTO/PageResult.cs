using System.Collections.Generic;

namespace FlightPlanner.Core.DTO
{
    public class PageResult
    {
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<Core.Models.Flight> Items { get; set; }

        public PageResult(List<Core.Models.Flight> pageResultList)
        {
            Items = pageResultList;
            TotalItems = Items.Count;
            Page = 0;
        }
    }
}
