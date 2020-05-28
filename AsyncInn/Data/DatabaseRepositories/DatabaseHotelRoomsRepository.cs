using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using AsyncInn.Models.ApiRecievals;
using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.DatabaseRepositories
{
    public class DatabaseHotelRoomsRepository : IHotelRoomRepository
    {
        public Task<HotelRoom> CreateHotelRoom()
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> CreateHotelRoom(CreateHotelRoom hotelRoomData)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetHotelRoomById(long hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelRoomDTO>> GetHotelRooms()
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> RemoveHotelRoom(int roomId, long hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> RemoveHotelRoom(long hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> SaveNewHotelRoom(CreateHotelRoom hotelRoomData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHotelRooms()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHotelRooms(long hotelId, CreateHotelRoom hotelRoomData)
        {
            throw new NotImplementedException();
        }
    }
}
