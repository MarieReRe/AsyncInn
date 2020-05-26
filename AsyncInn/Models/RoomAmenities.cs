using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenitiesId { get; set; }

        public long RoomId { get; set; }
      
        //Nav Properties
        public Amenities Amenities { get; set; }

        public Room Room { get; set; }


        
       
    }
}
