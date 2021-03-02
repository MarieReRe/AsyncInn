using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Data.DatabaseRepositories
{
    public class DatabaseRoomRepository : IRoomRepository
    {

        private readonly AsyncInnDbContext _context;

        public DatabaseRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Room> CreateRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> DeleteRoom(long id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<RoomDTO> GetRoomById(long id)
        {
            var room = await _context.Room
                 .Select(room => new RoomDTO
                 {
                     Id = room.Id,
                     Name = room.Name,
                     Style = room.Style.ToString(),

                     Amenities = room.Amenities
                     .Select(ra => new AmenityDTO
                     {
                         Id = ra.Amenities.Id,
                         Name = ra.Amenities.Name,
                     })
                     .ToList()

                 })
                 .FirstOrDefaultAsync(room => room.Id == id);
            return room;
        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            //return await _context.Room.ToListAsync();
            var rooms = await _context.Room
                .Select(room => new RoomDTO
                {
                    Id = room.Id,
                    Name = room.Name,
                    Style = room.Style.ToString(),

                    Amenities = room.Amenities
                     .Select(ra => new AmenityDTO
                     {
                         Id = ra.Amenities.Id,
                         Name = ra.Amenities.Name,
                     })
                     .ToList()

                })
                .ToListAsync();


            return rooms;
        }

        public async Task<bool> UpdateRoom(long id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
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
            }

        }

        public bool RoomExists(long id)
        {
            return _context.Room.Any(e => e.Id == id);
        }
        public async Task<Room> SaveNewRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }







        public async Task AddAmenityToRoom(int amenityId, long roomId)
        {
            var roomAmenity = new RoomAmenities
            {
                AmenitiesId = amenityId,
                RoomId = roomId,
            };
            _context.RoomAmenities.Add(roomAmenity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int amenityId, long roomId)
        {
            var roomAmenity = await _context.RoomAmenities
                .Where(ra => ra.AmenitiesId == amenityId)
                .Where(ra => ra.RoomId == roomId)
                .FirstOrDefaultAsync();

            if (roomAmenity != null)
            {
                _context.RoomAmenities.Remove(roomAmenity);
                await _context.SaveChangesAsync();
            }
        }
    }
}