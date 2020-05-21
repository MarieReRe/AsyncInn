using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public long HotelId { get; set; }
        public Hotel Hotel { get; set; }
        

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public Room Room { get; set; }

        public long RoomId { get; set; }
    }
}
