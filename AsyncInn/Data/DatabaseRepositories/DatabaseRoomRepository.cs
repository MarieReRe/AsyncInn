using AsyncInn.Data.Interfaces;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if(room == null)
            {
                return null;
            }
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> GetRoomById(long id)
        {
            return await _context.Room.FindAsync();
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Room.ToListAsync();
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
