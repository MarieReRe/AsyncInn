using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncInn.Models;
using AsyncInn.Models.ApiRecievals;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Data.Interfaces
{
    public interface IHotelRoomRepository
    {
        // Create: POST
        Task<HotelRoomDTO> CreateHotelRoom(long hotelId, CreateHotelRoom hotelRoomData);
        //READ: GET
        Task<HotelRoomDTO> GetHotelRoomByNumber(int roomNumber, long hotelId);
        Task<IEnumerable<HotelRoomDTO>> GetHotelRooms(long hotelId);


        //UPDATE: PUT
        Task<bool> UpdateHotelRooms(long hotelId, CreateHotelRoom hotelRoomData);

        //DELETE: DELETE
        Task<HotelRoom> RemoveHotelRoom(int roomNumber, long hotelId);
    }
}
