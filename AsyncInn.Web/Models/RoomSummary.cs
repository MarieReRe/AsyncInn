using System.Collections.Generic;

namespace AsyncInn.Web.Models
{
    public class RoomSummary
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public List<AmenitySummary> Amenities { get; set; }
    }
}