namespace AsyncInn.Models.DTOs
{
    public class HotelRoomDTO
    {
        public long HotelId { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public RoomDTO Room { get; set; }
    }
}
