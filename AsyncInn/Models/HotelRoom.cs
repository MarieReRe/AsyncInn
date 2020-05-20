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
        public int RoomId { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public decimal Rate { get; set; }
    }
}
