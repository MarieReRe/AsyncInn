using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.ApiRecievals
{
    public class CreateHotelRoom
    {
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public decimal Rate { get; set; }

        [Required]
        public long RoomId { get; set; }
    }
}
