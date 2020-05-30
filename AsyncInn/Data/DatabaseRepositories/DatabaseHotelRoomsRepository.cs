using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using AsyncInn.Models.ApiRecievals;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.DatabaseRepositories
{
    public class DatabaseHotelRoomsRepository : IHotelRoomRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseHotelRoomsRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoomDTO> CreateHotelRoom(CreateHotelRoom hotelRoomData)
        {

            var room = await _context.Room.FindAsync(hotelRoomData.RoomId);
            if(room == null)
            {
                return null;
            }
            var hotelRoom = new HotelRoom
            {
              RoomNumber = hotelRoomData.RoomNumber,
              Rate = hotelRoomData.Rate,
              RoomId = hotelRoomData.RoomId,
            };

            _context.HotelRoom.Add(hotelRoom);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.Id }, hotelRoom);
            var newHotelRoom = await GetHotelRoomById(hotelRoom.RoomNumber, hotelRoomData.RoomId);

            return newHotelRoom;
        }

     
        public Task<HotelRoomDTO> GetHotelRoomById(int roomNumber, long hotelId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HotelRoomDTO>> GetHotelRooms(long hotelId)
        {

          return await _context.HotelRoom
                .Where(hr => hr.HotelId == hotelId)
                .Select(hr => new HotelRoomDTO
                {
                    HotelId = hr.HotelId,
                    RoomNumber = hr.RoomNumber,
                    Name = hr.Name,
                    Style = hr.Style, 

                })
        }

        public Task<HotelRoom> RemoveHotelRoom(int roomId, long hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> RemoveHotelRoom(long hotelId)
        {
            throw new NotImplementedException();
        }



        public Task<bool> UpdateHotelRooms(long hotelId, CreateHotelRoom hotelRoomData)
        {
            throw new NotImplementedException();
            /* var hotelRoom = new HotelRoom
             {
                 RoomNumber = hotelRoomData.RoomNumber,
                 Rate = hotelRoomData.Rate,
                 RoomId = hotelRoomData.RoomId,
             };

             _context.Entry(hotelRoom).State = EntityState.Modified;
             try
             {
                 await _context.SaveChangesAsync();
                 return true;
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!RoomExists(id))
                 {
                     return false;
                 }
                 else
                 {
                     throw;
                 }
             }*/
        }
    }
}
