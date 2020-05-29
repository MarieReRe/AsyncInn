using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using AsyncInn.Models.ApiRecievals;
using AsyncInn.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Data.DatabaseRepositories
{
    public class DatabaseHotelRoomsRepository : IHotelRoomRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseHotelRoomsRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoomDTO> CreateHotelRoom(long hotelId, CreateHotelRoom hotelRoomData)
        {
            var hotelRoom = new HotelRoom
            {
                HotelId = hotelId,
                RoomNumber = hotelRoomData.RoomNumber,
                Rate = hotelRoomData.Rate,
                RoomId = hotelRoomData.RoomId,
            };

            _context.HotelRoom.Add(hotelRoom);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.Id }, hotelRoom);
            var newHotelRoom = await GetHotelRoomByNumber(hotelRoom.RoomNumber, hotelRoomData.RoomId);

            return newHotelRoom;
        }


        public async Task<HotelRoomDTO> GetHotelRoomByNumber(int roomNumber, long hotelId)
        {
            return await _context.HotelRoom
                .Where(hr => hr.HotelId == hotelId)
                .Where(hr => hr.RoomNumber == roomNumber)
                .Select(hr => new HotelRoomDTO
                {
                    HotelId = hr.HotelId,
                    RoomNumber = hr.RoomNumber,
                    Rate = hr.Rate,
                    Room = new RoomDTO
                    {
                        Id = hr.Room.Id,
                        Name = hr.Room.Name,
                        Style = hr.Room.Style.ToString(),

                        Amenities = hr.Room.Amenities
                            .Select(ra => new AmenityDTO
                            {
                                Id = ra.Amenities.Id,
                                Name = ra.Amenities.Name,
                            })
                            .ToList(),
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HotelRoomDTO>> GetHotelRooms(long hotelId)
        {
            return await _context.HotelRoom
                .Where(hr => hr.HotelId == hotelId)
                .Select(hr => new HotelRoomDTO
                {
                    HotelId = hr.HotelId,
                    RoomNumber = hr.RoomNumber,
                    Rate = hr.Rate,
                    Room = new RoomDTO
                    {
                        Id = hr.Room.Id,
                        Name = hr.Room.Name,
                        Style = hr.Room.Style.ToString(),

                        Amenities = hr.Room.Amenities
                            .Select(ra => new AmenityDTO
                            {
                                Id = ra.Amenities.Id,
                                Name = ra.Amenities.Name,
                            })
                            .ToList(),
                    }
                })
                .ToListAsync();
        }

        public async Task<HotelRoomDTO> RemoveHotelRoom(int roomNumber, long hotelId)
        {
            var hotelRoom = await _context.HotelRoom
                .FirstOrDefaultAsync(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber);

            if (hotelRoom == null)
                return null;

            var hotelRoomToReturn = await GetHotelRoomByNumber(roomNumber, hotelId);

            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();

            return hotelRoomToReturn;
        }

        public async Task<bool> UpdateHotelRooms(long hotelId, CreateHotelRoom hotelRoomData)
        {
            var hotelRoom = await _context.HotelRoom
                .FirstOrDefaultAsync(hr => hr.HotelId == hotelId && hr.RoomNumber == hotelRoomData.RoomNumber);

            if (hotelRoom == null)
                return false;

            hotelRoom.Rate = hotelRoomData.Rate;
            hotelRoom.RoomId = hotelRoomData.RoomId;

            _context.Entry(hotelRoom).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
