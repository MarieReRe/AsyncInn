using System.ComponentModel.DataAnnotations;

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
