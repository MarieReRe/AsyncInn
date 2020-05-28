using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Interfaces
{
    public interface IHotelRoomRepository
    {
        // Create: POST
        Task<HotelRoom> CreateHotelRoom();
        //READ: GET
        Task<HotelRoom> GetHotelRoomById(long hotelId);
        Task<IEnumerable<HotelRoomDTO>> GetHotelRooms();


        //UPDATE: PUT
        Task<bool> UpdateHotelRooms();

        //DELETE: DELETE
        Task<HotelRoom> RemoveHotelRoom(int roomId, long hotelId);
    }
}
