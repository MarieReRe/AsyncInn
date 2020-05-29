using AsyncInn.Models;
using AsyncInn.Models.ApiRecievals;
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
        Task<HotelRoomDTO> CreateHotelRoom(CreateHotelRoom hotelRoomData);
        //READ: GET
        Task<HotelRoomDTO> GetHotelRoomById(int roomNumber, long hotelId);
        Task<IEnumerable<HotelRoomDTO>> GetHotelRooms();


        //UPDATE: PUT
        Task<bool> UpdateHotelRooms(long hotelId, CreateHotelRoom hotelRoomData);
        Task<HotelRoom> SaveNewHotelRoom(CreateHotelRoom hotelRoomData);

        //DELETE: DELETE
        Task<HotelRoom> RemoveHotelRoom(int roomNumber, long hotelId);
    }
}
